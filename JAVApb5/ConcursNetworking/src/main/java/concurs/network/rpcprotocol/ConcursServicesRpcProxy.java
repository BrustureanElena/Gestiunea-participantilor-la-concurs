package concurs.network.rpcprotocol;

import concurs.domain.*;
import concurs.service.ConcursException;
import concurs.service.IConcursObserver;
import concurs.service.IConcursService;


import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.sql.SQLException;
import java.util.Collection;
import java.util.List;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.LinkedBlockingQueue;

//CONTROLERUL CAND VREA SA APELEZE O METODA DIN SERVICE, VA APELA DIN PROXY (IMPLEMENTAREA DE PE PROXY)
//Asta e folosit doar de client, CLIENTUL FACE CERERI PRIN PROXY
public class ConcursServicesRpcProxy implements IConcursService {
    private String host;
    private int port;
    private IConcursObserver client; //ASTA O SA FIE UN CONTROLLER
    private ObjectInputStream input;
    private ObjectOutputStream output;
    private Socket connection;
    private BlockingQueue<Response> qresponses;
    private volatile boolean finished;

    public ConcursServicesRpcProxy(String host, int port) {
        this.host = host;
        this.port = port;
        this.qresponses = new LinkedBlockingQueue<Response>();
    }

    @Override
    public void addParticipant(String nume, String prenume, int varsta) {
       //mai revad
    }

    @Override
    public void addInscriere(Inscriere inscriere) throws ConcursException {
      // Participant participant=new Participant(nume,prenume,varsta);
       //aici participant sau findOne???????????????
        //Inscriere mdto = new Inscriere(participant,proba);
        Request req = new Request.Builder().type(RequestType.INSCRIE).data(inscriere).build();
        this.sendRequest(req);
        Response response = this.readResponse();
        if (response.type() == ResponseType.ERROR) {
            String err = response.data().toString();
            throw new ConcursException(err);
        }
    }

    public void login(AngajatOficiu angajatOficiu, IConcursObserver obs) throws ConcursException {
        initializeConnection();
     //   AngajatOficiu an=new AngajatOficiu(user,parola);
        Request req = (new Request.Builder()).type(RequestType.LOGIN).data(angajatOficiu).build();
        this.sendRequest(req);
        Response response = this.readResponse();
        if (response.type() == ResponseType.LOGGED_IN) {
            this.client = obs;
            return;
        }
        if (response.type() == ResponseType.ERROR) {
            String err = response.data().toString();
            this.closeConnection();
            throw new ConcursException(err);
        }
    }

    //DE MODIFICAT
    @Override
    public void logout(AngajatOficiu angajatOficiu,IConcursObserver client) throws ConcursException {

        Request req=new Request.Builder().type(RequestType.LOGOUT).data(angajatOficiu).build();
        sendRequest(req);
        Response response=readResponse();
        closeConnection();
        if (response.type()== ResponseType.ERROR){
            String err=response.data().toString();
            throw new ConcursException(err);
        }
    }

    @Override
    public int getNrInscrisiProba(Proba proba) {
        return 0;
    }

    @Override
    public Iterable<Proba> getToateProbele() throws ConcursException {
        Request req = (new Request.Builder()).type(RequestType.GET_PROBE).data(null).build();
        this.sendRequest(req);
        Response response = this.readResponse();
        if (response.type() == ResponseType.ERROR) {
            String err = response.data().toString();
            throw new ConcursException(err);
        }
        List<Proba> spectacole = (List<Proba>)response.data();
        return spectacole;
       // return null;
    }

    @Override
    public Collection<ProbaDTO> getToateProbeleDTO() throws ConcursException {
        Request req = (new Request.Builder()).type(RequestType.GET_PROBE).data(null).build();
        this.sendRequest(req);
        Response response = this.readResponse();
        if (response.type() == ResponseType.ERROR) {
            String err = response.data().toString();
            throw new ConcursException(err);
        }
        List<ProbaDTO> spectacole = (List<ProbaDTO>)response.data();
        return spectacole;

    }

    @Override
    public Iterable<Participant> getTotiParticipantii() throws SQLException {
        return null;
    }

    @Override
    public Collection<? extends Participant> getParticipantiProbaVarsta(Proba proba) throws ConcursException {

        Request req = (new Request.Builder()).type(RequestType.CAUTA_PARTICIPANTI).data(proba).build();
        this.sendRequest(req);
        Response response = this.readResponse();
        if (response.type() == ResponseType.ERROR) {
            String err = response.data().toString();
            throw new ConcursException(err);
        }
        List<Participant> participanti = (List<Participant>)response.data();
        return participanti;
    }

    @Override
    public Participant findOneByNumePrenume(String numeDat, String prenumeDat) {
        return null;
    }

    @Override
    public Proba findOneByDenumireVarsta(String denumire, int varstaMin, int varstaMax) {
        return null;
    }




    private void closeConnection() {
        this.finished = true;
        try {
            this.input.close();
            this.output.close();
            this.connection.close();
            this.client = null;
        } catch (IOException var2) {
            var2.printStackTrace();
        }

    }

    private void sendRequest(Request request) throws ConcursException {
        try {
            this.output.writeObject(request);
            this.output.flush(); //OBIECTUL AJUNGE PE PARTEA CEALALTA
        } catch (IOException var3) {
            throw new ConcursException("Error sending object " + var3);
        }
    }

    private Response readResponse() throws ConcursException {
        Response response = null;
        try {
            response = (Response)this.qresponses.take();
        } catch (InterruptedException var3) {
            var3.printStackTrace();
        }
        return response;
    }

    private void initializeConnection() throws ConcursException {
        try {
            this.connection = new Socket(this.host, this.port);
            this.output = new ObjectOutputStream(this.connection.getOutputStream());
            this.output.flush();
            this.input = new ObjectInputStream(this.connection.getInputStream());
            this.finished = false;
            this.startReader(); //PORNIM THREADUL DE CITIRE
        } catch (IOException var2) {
            var2.printStackTrace();
        }

    }

    private void startReader() {
        Thread tw = new Thread(new ReaderThread());
        tw.start();
    }

    private void handleUpdate(Response response) {
        Inscriere sp =(Inscriere) response.data();
        System.out.println("Inscriere updated: " + sp);
        try {
                client.inscriereUpdated(sp);
        } catch (ConcursException var6) {
                var6.printStackTrace();
        }
    }

    private boolean isUpdate(Response response) {
        return response.type() == ResponseType.INSCRIERE_REALIZATA;
    }

    private class ReaderThread implements Runnable {
        public void run() {   //PANA FACEM LOGOUT, CITESTE TOT CE ESTE PE SOCKET
            while(!finished) {
                try {
                    Object response =input.readObject();
                    System.out.println("response received " + response);
                    if (isUpdate((Response)response)) {
                        handleUpdate((Response)response);
                    } else {
                        try {
                            qresponses.put((Response)response); //COADA DE RASPUNSURI, AICI SE FACE SINCRONIZAREA
                        } catch (InterruptedException var3) {
                            var3.printStackTrace();
                        }
                    }
                } catch (IOException var4) {
                    System.out.println("Reading error " + var4);
                } catch (ClassNotFoundException var5) {
                    System.out.println("Reading error " + var5);
                }
            }

        }
    }
}
