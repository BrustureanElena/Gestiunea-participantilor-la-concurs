package concurs.network.utils;

import concurs.network.protobuffprotocol.ProtoConcursWorker;
import concurs.network.rpcprotocol.ConcursClientRpcReflectionWorker;
import concurs.service.IConcursService;

import java.net.Socket;

public class ConcursProbuffConcurrentServer extends AbstractConcurrentServer {
    private IConcursService chatServer;
    public ConcursProbuffConcurrentServer(int port, IConcursService chatServer) {
        super(port);
        this.chatServer = chatServer;
        System.out.println("Chat- ChatRpcConcurrentServer");
    }



    @Override
    protected Thread createWorker(Socket client) {
        // ChatClientRpcWorker worker=new ChatClientRpcWorker(chatServer, client);
        ProtoConcursWorker worker=new ProtoConcursWorker(chatServer,client);
        Thread tw=new Thread(worker);
        return tw;
    }


}
