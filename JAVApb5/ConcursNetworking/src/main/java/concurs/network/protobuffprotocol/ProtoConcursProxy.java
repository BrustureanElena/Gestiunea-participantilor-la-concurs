package concurs.network.protobuffprotocol;

import concurs.domain.*;
import concurs.network.rpcprotocol.*;
import concurs.service.ConcursException;
import concurs.service.IConcursObserver;
import concurs.service.IConcursService;

import java.io.*;
import java.net.Socket;
import java.sql.SQLException;
import java.util.Arrays;
import java.util.Collection;
import java.util.List;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.LinkedBlockingQueue;

public class ProtoConcursProxy implements IConcursService {
    private String host;
    private int port;
    private IConcursObserver client; //ASTA O SA FIE UN CONTROLLER

    private InputStream input;
    private OutputStream output;
    private Socket connection;

    private BlockingQueue<ConcursProtobufs.ConcursResponse> qresponses;
    private volatile boolean finished;

    public ProtoConcursProxy(String host, int port) {
        this.host = host;
        this.port = port;
        qresponses=new LinkedBlockingQueue<ConcursProtobufs.ConcursResponse>();
    }

    @Override
    public void addParticipant(String nume, String prenume, int varsta) {

    }

    @Override
    public void addInscriere(Inscriere inscriere) throws ConcursException {
        // Participant participant=new Participant(nume,prenume,varsta);
        //aici participant sau findOne???????????????
        //Inscriere mdto = new Inscriere(participant,proba);
       // Request req = new Request.Builder().type(RequestType.INSCRIE).data(inscriere).build();
        this.sendRequest(ProtoUtils.createInscrieRequest(inscriere));
        ConcursProtobufs.ConcursResponse response=readResponse();

       // Response response = this.readResponse();
        if (response.getType() == ConcursProtobufs.ConcursResponse.Type.Error) {
            String err = ProtoUtils.getError(response);
            throw new ConcursException(err);
        }
    }
    @Override
    public Collection<? extends Participant> getParticipantiProbaVarsta(Proba proba) throws ConcursException {

       // Request req = (new Request.Builder()).type(RequestType.CAUTA_PARTICIPANTI).data(proba).build();
      //  this.sendRequest(req);
      //  Response response = this.readResponse();
        sendRequest(ProtoUtils.createCautaParticipantiRequest(proba));
        ConcursProtobufs.ConcursResponse response=readResponse();

        if (response.getType() == ConcursProtobufs.ConcursResponse.Type.Error) {
            String errorText=ProtoUtils.getError(response);
            throw new ConcursException(errorText);
        }
        List<Participant> participanti = Arrays.asList(ProtoUtils.getParticipanti(response));
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

    @Override
    public Iterable<Proba> getToateProbele() throws ConcursException {
        sendRequest(ProtoUtils.createGetProbeRequest());
        ConcursProtobufs.ConcursResponse response=readResponse();
        if (response.getType() == ConcursProtobufs.ConcursResponse.Type.Error) {
            String errorText=ProtoUtils.getError(response);
            throw new ConcursException(errorText);
        }
        List<Proba> probe = Arrays.asList(ProtoUtils.getProbe(response));
        return probe;
        // return null;
    }

    @Override
    public Collection<ProbaDTO> getToateProbeleDTO() throws ConcursException {
        sendRequest(ProtoUtils.createGetProbeDTORequest());
        ConcursProtobufs.ConcursResponse response=readResponse();
        if (response.getType() == ConcursProtobufs.ConcursResponse.Type.Error) {
            String errorText=ProtoUtils.getError(response);
            throw new ConcursException(errorText);
        }
        List<ProbaDTO> probe = Arrays.asList(ProtoUtils.getProbeDTO(response));
        return probe;
    }

    @Override
    public Iterable<Participant> getTotiParticipantii() throws SQLException {
        return null;
    }

    public void login(AngajatOficiu angajatOficiu, IConcursObserver obs) throws ConcursException {
        initializeConnection();
        //   AngajatOficiu an=new AngajatOficiu(user,parola);

        sendRequest(ProtoUtils.createLoginRequest(angajatOficiu));

        ConcursProtobufs.ConcursResponse response=readResponse();


       // Request req = (new Request.Builder()).type(RequestType.LOGIN).data(angajatOficiu).build();

        //Response response = this.readResponse();
        System.out.println("login              ------"+response);
        if (response.getType() == ConcursProtobufs.ConcursResponse.Type.Ok) {
            this.client = obs;
            System.out.println("login"+obs);
            return;

        }
        if (response.getType() == ConcursProtobufs.ConcursResponse.Type.Error) {
            String err = ProtoUtils.getError(response);
           closeConnection();
            throw new ConcursException(err);
        }
    }

    @Override
    public void logout(AngajatOficiu angajatOficiuCurent, IConcursObserver client) throws ConcursException {
        sendRequest(ProtoUtils.createLogoutRequest(angajatOficiuCurent));
        ConcursProtobufs.ConcursResponse response=readResponse();

        closeConnection();
        if (response.getType()== ConcursProtobufs.ConcursResponse.Type.Error){
            String errorText=ProtoUtils.getError(response);
            throw new ConcursException(errorText);
        }
    }


    @Override
    public int getNrInscrisiProba(Proba proba) {
        return 0;
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
    private ConcursProtobufs.ConcursResponse readResponse() throws ConcursException {
        ConcursProtobufs.ConcursResponse response = null;
        try {
            response = qresponses.take();
        } catch (InterruptedException var3) {
            var3.printStackTrace();
        }
        return response;
    }


    private void sendRequest(ConcursProtobufs.ConcursRequest request) throws ConcursException {
        try {
            request.writeDelimitedTo(output);
            output.flush(); //OBIECTUL AJUNGE PE PARTEA CEALALTA
        } catch (IOException var3) {
            throw new ConcursException("Error sending object " + var3);
        }
    }

    private void initializeConnection() throws ConcursException{
        try {
            connection=new Socket(host,port);
            output=connection.getOutputStream();
            //output.flush();
            input=connection.getInputStream();     //new ObjectInputStream(connection.getInputStream());
            finished=false;
            startReader();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    private void startReader() {
        Thread tw = new Thread(new ReaderThread());
        tw.start();
    }
    private boolean isUpdate(Response response) {
        return response.type() == ResponseType.INSCRIERE_REALIZATA;
    }





    private void handleUpdate(ConcursProtobufs.ConcursResponse response) {


        Inscriere inscriere=ProtoUtils.getInscriere(response);
        System.out.println("Inscriere updated: " + inscriere);
        System.out.println("client"+client);
        try {
            client.inscriereUpdated(inscriere);
        } catch (ConcursException var6) {
            var6.printStackTrace();
        }
    }


    private class ReaderThread implements Runnable{
        public void run() {
            while(!finished){
                try {
                    ConcursProtobufs.ConcursResponse response=ConcursProtobufs.ConcursResponse.parseDelimitedFrom(input);
                    System.out.println("response received "+response);

                    if (isUpdateResponse(response.getType())){
                        handleUpdate(response);
                    }else{
                        try {
                            qresponses.put(response);
                        } catch (InterruptedException e) {
                            e.printStackTrace();
                        }
                    }
                } catch (IOException e) {
                    System.out.println("Reading error "+e);
                }
            }
        }
    }
    private boolean isUpdateResponse(ConcursProtobufs.ConcursResponse.Type type){
        switch (type){

            case InscriereRealizata: return true;

        }
        return false;
    }
}
