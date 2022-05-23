using System;
using System.Net.Sockets;
using System.Threading;
using persistence;
using ServerTemplate;
using services;

namespace Server
{
     class StartServer
    {
        static void Main(string[] args)
        {
            
            
            IParticipantRepository participantRepo=new ParticipantDBRepository();
            IProbaRepository probaRepo=new ProbaDBRepository();
            IAngajatOficiuRepository angajatRepo = new AngajatOficiuDBRepository();
            IInscriereRepository inscriereRepository = new InscriereDBRepository(participantRepo, probaRepo);
            IConcursServices serviceImpl =
                new ConcursServerImpl(participantRepo, probaRepo, inscriereRepository, angajatRepo);
         
            SerialConcursServer server = new SerialConcursServer("127.0.0.1", 55555, serviceImpl);
            server.Start();
            Console.WriteLine("Server started ...");
            //Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();
            
        }
    }

    public class SerialConcursServer: ConcurrentServer 
    {
        private IConcursServices server;
        private ConcursClientWorker worker;
        public SerialConcursServer(string host, int port, IConcursServices server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("SerialChatServer...");
        }
        protected override Thread createWorker(TcpClient client)
        {
            worker = new ConcursClientWorker(server, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
    }
