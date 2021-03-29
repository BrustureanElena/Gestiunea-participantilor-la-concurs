package networking.utils;

import concurs.service.IConcursService;
import networking.rpcprotocol.ConcursClientRpcReflectionWorker;


import java.net.Socket;

//asta e de pe server
// de fiecare data cand se conecteaza un client, ConcursConcurentServer ne creeaza un worker
//ReaderThread   -   Proxy   -   Worker
public class ConcursConcurrentServer extends AbstractConcurrentServer {
    private IConcursService chatServer;
    public ConcursConcurrentServer(int port, IConcursService chatServer) {
        super(port);
        this.chatServer = chatServer;
        System.out.println("Chat- ChatRpcConcurrentServer");
    }



    @Override
    protected Thread createWorker(Socket client) {
        // ChatClientRpcWorker worker=new ChatClientRpcWorker(chatServer, client);
        ConcursClientRpcReflectionWorker worker=new ConcursClientRpcReflectionWorker(chatServer, client);

        Thread tw=new Thread(worker);
        return tw;
    }

    @Override
    public void stop(){
        System.out.println("Stopping services ...");
    }
}
