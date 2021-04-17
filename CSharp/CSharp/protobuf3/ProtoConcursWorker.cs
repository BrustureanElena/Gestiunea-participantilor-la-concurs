using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using model;
using services;
using Concurs.Protocol;
using Google.Protobuf;
using services;
using Inscriere= model.Inscriere;
using AngajatOficiu = model.AngajatOficiu;
using Participant = model.Participant;
using Proba = model.Proba;
using ProbaDTO=model.ProbaDTO;

namespace protobuf3
{
    public class ProtoConcursWorker : IConcursObserver
    {
        private IConcursServices server;
        private TcpClient connection;

        private NetworkStream stream;
        private volatile bool connected;

        public ProtoConcursWorker(IConcursServices server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {
                stream = connection.GetStream();
                connected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }


        public void run()
        {
            while (connected)
            {
                try
                {

                    Console.WriteLine("Waiting requests ...");
                    ConcursRequest request = ConcursRequest.Parser.ParseDelimitedFrom(stream);

                    Console.WriteLine("Request received: " + request);
                    ConcursResponse response = handleRequest(request);
                    if (response != null)
                    {
                        sendResponse(response);
                    }
                }
                catch (IOException var4)
                {
                    Console.WriteLine(var4.StackTrace);
                }

                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception var3)
                {
                    Console.WriteLine(var3.StackTrace);
                }
            }

            try
            {
                stream.Close();
                connection.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("Error " + e);
            }
        }


        private ConcursResponse handleRequest(ConcursRequest request)
        {

            ConcursResponse response = null;
            ConcursRequest.Types.Type reqType = request.Type;

            switch (reqType)
            {
                case ConcursRequest.Types.Type.Login:
                {
                    Console.WriteLine("Login request ...");
                    model.AngajatOficiu udto = ProtoUtils.GetAngajatOficiu(request);
                    try
                    {
                        lock (server)
                        {
                            server.login(udto, this);
                        }

                        return ProtoUtils.createOkResponse();
                    }
                    catch (ConcursException e)
                    {
                        connected = false;
                        return ProtoUtils.createErrorResponse(e.Message);
                    }
                }
                case ConcursRequest.Types.Type.Logout:
                {
                    Console.WriteLine("Logout request...");
                    model.AngajatOficiu org = ProtoUtils.GetAngajatOficiu(request);
                    try
                    {
                        lock (server)
                        {
                            server.logout(org, this);
                        }

                        connected = false;
                        return ProtoUtils.createOkResponse();
                    }
                    catch (ConcursException e)
                    {
                        return ProtoUtils.createErrorResponse(e.Message);
                    }
                }
                case ConcursRequest.Types.Type.Inscrie:
                {
                    Console.WriteLine("INSCRIERE request ...");
                    model.Inscriere inregistrare = ProtoUtils.getInscriere(request);
                    try
                    {
                        lock (server)
                        {
                            server.addInscriere(inregistrare);
                        }

                        return ProtoUtils.createOkResponse();
                    }
                    catch (ConcursException e)
                    {
                        return ProtoUtils.createErrorResponse(e.Message);
                    }
                }
                case ConcursRequest.Types.Type.CautaParticipanti:
                {
                    Console.WriteLine("Cauta PARTICIPANTI ...");
                    model.Proba proba = ProtoUtils.getProba(request);
                    try
                    {
                        List<model.Participant> participanti = new List<model.Participant>();
                        lock (server)
                        {
                            participanti = (List<Participant>) server.getParticipantiProbaVarsta(proba);
                        }

                        return ProtoUtils.createCautaParticipantiResponse(participanti);
                    }
                    catch (ConcursException e)
                    {
                        return ProtoUtils.createErrorResponse(e.Message);
                    }
                }
                case ConcursRequest.Types.Type.GetProbe:
                {
                    Console.WriteLine("GetPROBE Request ...");
                    try
                    {
                        List<model.Proba> probele = new List<model.Proba>();
                        lock (server)
                        {
                            probele = (List<Proba>) server.getToateProbele();
                        }

                        return ProtoUtils.createGetToateProbeResponse(probele);
                    }
                    catch (ConcursException e)
                    {
                        return ProtoUtils.createErrorResponse(e.Message);
                    }
                }
                case ConcursRequest.Types.Type.GetProbeDto:
                {
                    Console.WriteLine("GetPROBE Request ...");
                    try
                    {
                        List<model.ProbaDTO> probele = new List<model.ProbaDTO>();
                        lock (server)
                        {
                            probele = (List<ProbaDTO>) server.getToateProbeleDTO();
                        }

                        return ProtoUtils.createGetToateProbeDTOResponse(probele);
                    }
                    catch (ConcursException e)
                    {
                        return ProtoUtils.createErrorResponse(e.Message);
                    }
                }
            }

            return response;
        }



        private void sendResponse(ConcursResponse response)
        {
            Console.WriteLine("sending response " + response);
            lock (stream)
            {
                response.WriteDelimitedTo(stream);
                stream.Flush();
            }
        }


        public void inscriereUpdated(Inscriere inscriere)
        {
            Console.WriteLine("Inscriere adaugata:  "+ inscriere);
            try {
                sendResponse(ProtoUtils.createInscriereRealizataResponse(inscriere));
            } catch (IOException e) {
                throw new ConcursException("Sending error: "+e);
            }
        }
    }
}