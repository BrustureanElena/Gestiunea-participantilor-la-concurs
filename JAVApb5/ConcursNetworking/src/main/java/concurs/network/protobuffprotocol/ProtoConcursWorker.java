package concurs.network.protobuffprotocol;

import concurs.domain.*;
import concurs.network.rpcprotocol.Response;
import concurs.network.rpcprotocol.ResponseType;
import concurs.service.ConcursException;
import concurs.service.IConcursObserver;
import concurs.service.IConcursService;

import java.io.*;
import java.net.Socket;
import java.util.List;

public class ProtoConcursWorker implements Runnable, IConcursObserver {
    private IConcursService server;
    private Socket connection;

    private InputStream input;
    private OutputStream output;
    private volatile boolean connected;
    public ProtoConcursWorker(IConcursService server, Socket connection) {
        this.server = server;
        this.connection = connection;
        try{
            output=connection.getOutputStream() ;//new ObjectOutputStream(connection.getOutputStream());
            input=connection.getInputStream(); //new ObjectInputStream(connection.getInputStream());
            connected=true;
        } catch (IOException e) {
            e.printStackTrace();
        }
    }


    @Override
    public void run() {
        while(connected){
            try {
                // Object request=input.readObject();
                System.out.println("Waiting requests ...");
                ConcursProtobufs.ConcursRequest request=ConcursProtobufs.ConcursRequest.parseDelimitedFrom(input);
                System.out.println("Request received: "+request);
                ConcursProtobufs.ConcursResponse response=handleRequest(request);
                if (response!=null){
                    sendResponse(response);
                }
            } catch (IOException e) {
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
    private ConcursProtobufs.ConcursResponse handleRequest(ConcursProtobufs.ConcursRequest request){
        ConcursProtobufs.ConcursResponse response=null;
        switch (request.getType()){
            case Login:{
                System.out.println("Login request ...");

                AngajatOficiu angajatOficiu=ProtoUtils.getAngajatOficiu(request);
                try {
                    server.login(angajatOficiu, this);
                    return ProtoUtils.createOkResponse();
                } catch (ConcursException e) {
                    connected=false;
                    return ProtoUtils.createErrorResponse(e.getMessage());
                }
            }
            case Logout:{
                System.out.println("Logout request");
                AngajatOficiu angajatOficiu2=ProtoUtils.getAngajatOficiu(request);
                try {
                    server.logout(angajatOficiu2, this);
                    connected=false;
                    return ProtoUtils.createOkResponse();

                } catch (ConcursException e) {
                    return ProtoUtils.createErrorResponse(e.getMessage());
                }
            }
            case Inscrie:{
                System.out.println("InscriereRequest ...");
                Inscriere inscriere=ProtoUtils.getInscriere(request);

                try {
                    server.addInscriere(inscriere);
                    return ProtoUtils.createOkResponse();
                   // return ProtoUtils.createInscriereRealizataResponse(inscriere);
                } catch (ConcursException e) {
                    return ProtoUtils.createErrorResponse(e.getMessage());
                }
            }
            case CautaParticipanti:{
                System.out.println("Cauta participanti Request ...");
                Proba proba=ProtoUtils.getProba(request);
                try {
                    Participant[] participants= server.getParticipantiProbaVarsta(proba).toArray(new Participant[0]);
                    return ProtoUtils.createCautaParticipantiResponse(participants);
                } catch (ConcursException e) {
                    return ProtoUtils.createErrorResponse(e.getMessage());
                }
            }
            case GetProbe:{
                System.out.println("GetProbe Request ...");
                try {
                    List<Proba> spectacole= (List<Proba>) server.getToateProbele();
                    return  ProtoUtils.createGetProbeResponse(spectacole);

                } catch ( ConcursException e) {
                    return ProtoUtils.createErrorResponse(e.getMessage());
                }
            }
            case GetProbeDTO:{
                System.out.println("GetProbeDTO Request ...");
                try {
                    List<ProbaDTO> spectacole= (List<ProbaDTO>) server.getToateProbeleDTO();
                    return  ProtoUtils.createGetProbeDTOResponse(spectacole);

                } catch ( ConcursException e) {
                    return ProtoUtils.createErrorResponse(e.getMessage());
                }
            }
            }


        return response;
    }

    private void sendResponse(ConcursProtobufs.ConcursResponse response) throws IOException{
        System.out.println("sending response "+response);
        response.writeDelimitedTo(output);
        //output.writeObject(response);
        output.flush();
    }

    @Override
    public void inscriereUpdated(Inscriere spectacol) throws ConcursException{
       // Response resp=new Response.Builder().type(ResponseType.INSCRIERE_REALIZATA).data(spectacol).build();
        System.out.println("Spectacol updated:  "+spectacol);
        try {
            sendResponse(ProtoUtils.createInscriereRealizataResponse(spectacol));
        } catch (IOException e) {
            throw new ConcursException("Sending error: "+e);
        }
    }
}
