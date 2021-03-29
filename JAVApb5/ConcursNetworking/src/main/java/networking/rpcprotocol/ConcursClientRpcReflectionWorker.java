package networking.rpcprotocol;

import concurs.domain.*;
import concurs.service.ConcursException;
import concurs.service.IConcursObserver;
import concurs.service.IConcursService;


import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.net.Socket;
import java.util.List;


// asta e folosit de server


//TINE LOCUL CLIENTULUI IN PROCESUL SERVER


//ACESTA COMUNICA PRIN RETEA CU PROXYUL,
//cand vine o inf de la client de login de ex, Proxy trimite inf coresp prin socket la Worker
//workerul citeste inf de pe socket, apeleaza IService
public class ConcursClientRpcReflectionWorker implements Runnable, IConcursObserver {
    private IConcursService server;
    private Socket connection;

    private ObjectInputStream input;
    private ObjectOutputStream output;
    private volatile boolean connected;
    public ConcursClientRpcReflectionWorker(IConcursService server, Socket connection) {
        this.server = server;
        this.connection = connection;
        try{
            output=new ObjectOutputStream(connection.getOutputStream());
            output.flush();
            input=new ObjectInputStream(connection.getInputStream());
            connected=true;
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void run() {
        while(connected){
            try {
                Object request=input.readObject();
                Response response=handleRequest((Request)request);
                if (response!=null){
                    sendResponse(response);
                }
            } catch (IOException e) {
                e.printStackTrace();
            } catch (ClassNotFoundException e) {
                e.printStackTrace();
            }
            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
        try {
            input.close();
            output.close();
            connection.close();
        } catch (IOException e) {
            System.out.println("Error "+e);
        }
    }
//DEOARECE E REFLECTION WORKER, STIE CE METODA SA SE APELEZE
    private static Response okResponse=new Response.Builder().type(ResponseType.OK).build();
    //  private static Response errorResponse=new Response.Builder().type(ResponseType.ERROR).build();
    private Response handleRequest(Request request){
        Response response=null;
        String handlerName="handle"+(request).type();
        System.out.println("HandlerName "+handlerName);
        try {
            Method method=this.getClass().getDeclaredMethod(handlerName, Request.class);
            response=(Response)method.invoke(this,request);
            System.out.println("Method "+handlerName+ " invoked");
        } catch (NoSuchMethodException e) {
            e.printStackTrace();
        } catch (IllegalAccessException e) {
            e.printStackTrace();
        } catch (InvocationTargetException e) {
            e.printStackTrace();
        }

        return response;
    }

    private Response handleLOGOUT(Request request){
        System.out.println("Logout request...");
        try {
            AngajatOficiu angajatOficiu=(AngajatOficiu)request.data();
            server.logout(angajatOficiu,this);
            connected=false;
            return okResponse;

        } catch (ConcursException e) {
            return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
        }
    }

    private Response handleLOGIN(Request request){
        System.out.println("Login request ..."+request.type());
        AngajatOficiu udto=(AngajatOficiu) request.data();
        try {
            server.login(udto,this);
            return new Response.Builder().type(ResponseType.LOGGED_IN).build();
        } catch (ConcursException e) {
            connected=false;
            return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
        }
    }
//aici????????

    private Response handleINSCRIE(Request request){
        System.out.println("INSCRIERequest ..."+request.type());
        Inscriere b=(Inscriere) request.data();
        try {
            server.addInscriere(b);

            return new Response.Builder().type(ResponseType.OK).build();
        } catch (ConcursException e) {
            return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
        }
    }

    private Response handleCAUTA_PARTICIPANTI(Request request){
        System.out.println("Cauta participanti Request ...");
        Proba sp= (Proba) request.data();
        try {
            List<Participant> spectacole= (List<Participant>) server.getParticipantiProbaVarsta(sp);
            return new Response.Builder().type(ResponseType.PARTICIPANTI_GASITI).data(spectacole).build();
        } catch (ConcursException e) {
            return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
        }
    }

    private void sendResponse(Response response) throws IOException{
        System.out.println("sending response "+response);
        output.writeObject(response);
        output.flush();
    }

    private Response handleGET_PROBE(Request request){
        System.out.println("GetSpectacole Request ...");
        try {
            List<ProbaDTO> spectacole= (List<ProbaDTO>) server.getToateProbeleDTO();
            return new Response.Builder().type(ResponseType.GOT_PROBE).data(spectacole).build();
        } catch ( ConcursException e) {
            return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
        }
    }

    @Override
    public void inscriereUpdated(Inscriere spectacol) throws ConcursException{
        Response resp=new Response.Builder().type(ResponseType.INSCRIERE_REALIZATA).data(spectacol).build();
        System.out.println("Spectacol updated:  "+spectacol);
        try {
            sendResponse(resp);
        } catch (IOException e) {
            throw new ConcursException("Sending error: "+e);
        }
    }
}

