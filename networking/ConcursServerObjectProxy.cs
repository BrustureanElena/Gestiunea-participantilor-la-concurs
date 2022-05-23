using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using model;
using services;


namespace networking
{
    public class ConcursServerProxy:IConcursServices
    {
        private string host;
        private int port;

        private IConcursObserver client;

        private NetworkStream stream;
		
        private IFormatter formatter;
        private TcpClient connection;

        private Queue<Response> responses;
        private volatile bool finished;
        private EventWaitHandle _waitHandle;
        public ConcursServerProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            responses=new Queue<Response>();
        }

        public void addParticipant(string nume, string prenume, int varsta)
        {
            throw new System.NotImplementedException();
        }
            // din void in Inscriere
        public virtual void addInscriere(Inscriere inscriere)
        {
            
            sendRequest(new AddInscriereRequest(inscriere));
            Response response = this.readResponse();
            Console.WriteLine("Proxy.AddInscriere: Am primit raspuns...");
            if(response is ErrorResponse){
                ErrorResponse err = (ErrorResponse) response;
                throw new Exception(err.Message);
            }
           
         

           
        }

        public virtual void login(AngajatOficiu angajatOficiu, IConcursObserver client)
        {
            
            initializeConnection();
            
            sendRequest(new LoginRequest(angajatOficiu));
            Response response =readResponse();
            if (response is OkResponse)
            {
                this.client=client;
                return;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse err =(ErrorResponse)response;
                closeConnection();
                throw new ConcursException(err.Message);
            }
        }

        public AngajatOficiu getConnectedUser()
        {
            throw new System.NotImplementedException();
        }

        public virtual void logout(AngajatOficiu user, IConcursObserver client)
        {
            
            sendRequest(new LogoutRequest(user));
            Response response = readResponse();
            closeConnection();

            if (response is ErrorResponse){
                ErrorResponse err = (ErrorResponse)response;
                throw new Exception(err.Message);
            }
        }

        public int getNrInscrisiProba(Proba proba)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Proba> getToateProbele()
        {
            sendRequest(new GetToateProbeleRequest());
            Response response = readResponse();
            Console.WriteLine("Proxy.getToateProbele Am primit raspuns...");
            if(response is ErrorResponse){
                ErrorResponse err = (ErrorResponse) response;
                throw new Exception(err.Message);
            }
            GetToateProbeleResponse resp = (GetToateProbeleResponse) response;
            Proba[] probe = resp.Probe;
            return new List<Proba>(probe);
        }

        public List<ProbaDTO> getToateProbeleDTO()
        {
            Console.WriteLine("in getToate Probele DTO ");
            sendRequest(new GetToateProbeleDTORequest());
            Response response = readResponse();
            Console.WriteLine("Proxy.getToateProbeleDTO Am primit raspuns...");
            if(response is ErrorResponse){
                ErrorResponse err = (ErrorResponse) response;
                throw new Exception(err.Message);
            }
            GetToateProbeleDTOResponse resp = (GetToateProbeleDTOResponse) response;
            ProbaDTO[] probe = resp.ProbeDTO;
            return new List<ProbaDTO>(probe);
        }

        public IEnumerable<Participant> getTotiParticipantii()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Participant> getParticipantiProbaVarsta(Proba proba)
        {
            sendRequest(new GetParticipantiProbaVarstaRequest(proba) );
            Response response = readResponse();
            Console.WriteLine("Proxy.GetParticipantProbaVarsta: Am primit raspuns...");
            if(response is ErrorResponse){
                ErrorResponse err = (ErrorResponse) response;
                throw new Exception(err.Message);
            }

            GetParticipantiProbaVarstaResponse resp = (GetParticipantiProbaVarstaResponse) response;
            Participant[] participanti = resp.ParticipantiDTO;
            return new List<Participant>(participanti);
        }

        public Participant findOneByNumePrenume(string numeDat, string prenumeDat)
        {
            throw new System.NotImplementedException();
        }

        public Proba findOneByDenumireVarsta(string denumire, int varstaMin, int varstaMax)
        {
            throw new System.NotImplementedException();
        }

        public Proba GetProba(long idP)
        {Console.WriteLine("Proxy.GetProba: Am primit raspuns.INAINTE..");
            sendRequest(new GetProbaRequest(idP));
            Response response = readResponse();
            Console.WriteLine("Proxy.GetProba: Am primit raspuns...");
            if(response is ErrorResponse){
                ErrorResponse err = (ErrorResponse) response;
                throw new Exception(err.Message);
            }

            GetProbaResponse resp = (GetProbaResponse) response;
            Proba proba = resp.Proba;
            Console.WriteLine(proba);
            return proba;
        }

        private void closeConnection()
        {
            finished=true;
            try
            {
                stream.Close();
                //output.close();
                connection.Close();
                _waitHandle.Close();
                client=null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        private void sendRequest(Request request)
        {
            try
            {
                formatter.Serialize(stream, request);
                stream.Flush();
            }
            catch (Exception e)
            {
                throw new ConcursException("Error sending object "+e);
            }

        }

        private Response readResponse()
        {
            Response response =null;
            try
            {
                _waitHandle.WaitOne();
                lock (responses)
                {
                    //Monitor.Wait(responses); 
                    response = responses.Dequeue();
                
                }
				

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }
        private void initializeConnection()
        {
            try
            {
                connection=new TcpClient(host,port);
                stream=connection.GetStream();
                formatter = new BinaryFormatter();
                finished=false;
                _waitHandle = new AutoResetEvent(false);
                startReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        private void startReader()
        {
            Thread tw =new Thread(run);
            tw.Start();
        }
        private void handleUpdate(UpdateResponse update)
        {
            if (update is AddInscriereResponse)
            {

                //Inscriere frUpd =(Inscriere)update;
                AddInscriereResponse inscriereResponse = (AddInscriereResponse) update;
                Inscriere inscriere = inscriereResponse.Inscriere;
                Console.WriteLine("Inregistrate logged in+ "+inscriere);
               
                try
                {
                    client.inscriereUpdated(inscriere);
                  
                }
                catch (ConcursException e)
                {
                    Console.WriteLine(e.StackTrace); 
                }
            }
           
            

           
        }
    
        public virtual void run()
        {
            while(!finished)
            {
                try
                {
                    object response = formatter.Deserialize(stream);
                    Console.WriteLine("response received "+response);
                    if (response is UpdateResponse)
                    {
                        handleUpdate((UpdateResponse)response);
                    }
                    else
                    {
							
                        lock (responses)
                        {
                                					
								 
                            responses.Enqueue((Response)response);
                               
                        }
                        _waitHandle.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Reading error "+e);
                }
					
            }
        }
    }
}