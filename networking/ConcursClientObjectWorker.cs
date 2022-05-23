using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using model;
using networking;
using services;

namespace ServerTemplate
{

	
	
	public class ConcursClientWorker :  IConcursObserver //, Runnable
	{
		private IConcursServices server;
		private TcpClient connection;

		private NetworkStream stream;
		private IFormatter formatter;
		private volatile bool connected;
		public ConcursClientWorker(IConcursServices server, TcpClient connection)
		{
			this.server = server;
			this.connection = connection;
			try
			{
				
				stream=connection.GetStream();
                formatter = new BinaryFormatter();
				connected=true;
			}
			catch (Exception e)
			{
                Console.WriteLine(e.StackTrace);
			}
		}

		public virtual void run()
		{
			while(connected)
			{
				try
				{
                    object request = formatter.Deserialize(stream);
					object response =handleRequest((Request)request);
					if (response!=null)
					{
					   sendResponse((Response) response);
					}
				}
				catch (Exception e)
				{
                    Console.WriteLine(e.StackTrace);
				}
				
				try
				{
					Thread.Sleep(1000);
				}
				catch (Exception e)
				{
                    Console.WriteLine(e.StackTrace);
				}
			}
			try
			{
				stream.Close();
				connection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error "+e);
			}
		}

		
			private Response handleRequest(Request request)
		{
			Response response =null;
			if (request is LoginRequest)
			{
				Console.WriteLine("Login request ...");
				LoginRequest logReq =(LoginRequest)request;
				AngajatOficiu user =logReq.User;
				
				try
                {
                    lock (server)
                    {
                        server.login(user, this);
                    }
					return new OkResponse();
				}
				catch (ConcursException e)
				{
					connected=false;
					return new ErrorResponse(e.Message);
				}
			}
			if (request is LogoutRequest)
			{
				Console.WriteLine("Logout request");
				LogoutRequest logReq =(LogoutRequest)request;
				AngajatOficiu user =logReq.User;
				
				try
				{
                    lock (server)
                    {

                        server.logout(user, this);
                    }
					connected=false;
					return new OkResponse();

				}
				catch (ConcursException e)
				{
				   return new ErrorResponse(e.Message);
				}
			
			
			}
			if(request is  GetToateProbeleRequest){
				Console.WriteLine("GetToateProbeleRequest...");
				GetToateProbeleRequest getToateProbeleRequest = ( GetToateProbeleRequest) request;
				try{
					
					IEnumerable<Proba> probe = server.getToateProbele();
					Proba[] probe1 = probe.ToArray();
					return new GetToateProbeleResponse(probe1);
				} catch (Exception e) {
					return new ErrorResponse(e.Message);
				}
			}
			if(request is  GetToateProbeleDTORequest){
				Console.WriteLine("GetToateProbeleDTORequest...");
				GetToateProbeleDTORequest getToateProbeleDTORequest = ( GetToateProbeleDTORequest) request;
				try{
					Console.WriteLine("inainte");
					List<ProbaDTO> probe = server.getToateProbeleDTO();
					Console.WriteLine("aici");
					ProbaDTO[] probe1 = probe.ToArray();
					return new GetToateProbeleDTOResponse(probe1);
				} catch (Exception e) {
					return new ErrorResponse(e.Message);
				}
			}
			if (request is GetProbaRequest)
			{
				Console.WriteLine("GetProba...");
				GetProbaRequest getProbaRequest = (GetProbaRequest) request;
				long idP = getProbaRequest.IdP;
				try
				{
					Proba proba = server.GetProba(idP);
					Console.WriteLine("GetProba inauntr"+proba);
					return new GetProbaResponse(proba);
				}
				catch (ConcursException e)
				{
					return new ErrorResponse(e.Message);
				}
			}
			if (request is GetParticipantiProbaVarstaRequest)
			{
				Console.WriteLine("GetParticipantiProbaVarstaDTO...");
				GetParticipantiProbaVarstaRequest getParticipantProbaVarstaDtoRequest = (GetParticipantiProbaVarstaRequest) request;
				Proba proba = getParticipantProbaVarstaDtoRequest.Proba;
				try
				{
					IEnumerable<Participant> participantDtos = server.getParticipantiProbaVarsta(proba);
					Participant[] participantDtos1 = participantDtos.ToArray();
					return new GetParticipantiProbaVarstaResponse(participantDtos1);
				}
				catch (ConcursException e)
				{
					return new ErrorResponse(e.Message);
				}
			}

			if(request is AddInscriereRequest){
				Console.WriteLine("Inscriere Request...");
				AddInscriereRequest inscriereRequest = (AddInscriereRequest) request;
				try{
				
					server.addInscriere(inscriereRequest.Inscriere );
					return new OkResponse();

				} catch (Exception e) {
					return new ErrorResponse(e.Message);
				}
			}
			
			
			return response;
		}

		
		public void inscriereUpdated(Inscriere inscriere)
		{
			Console.WriteLine("Inregistrare received  "+inscriere);
			try
			{
				sendResponse(new AddInscriereResponse(inscriere));
			}
			catch (Exception e)
			{
				throw new ConcursException("Sending error: "+e);
			}
		}
		
	
		private void sendResponse(Response response)
		{
			Console.WriteLine("sending response "+response);
			formatter.Serialize(stream, response);
			stream.Flush();
			
		}


		
	}

}