using System;
using System.Collections.Generic;
using Concurs.Protocol;
using Inscriere = model.Inscriere;
using proto=Concurs.Protocol;
namespace protobuf3
{
    public class ProtoUtils
    {
        public static model.AngajatOficiu GetAngajatOficiu (ConcursRequest request){
            model.AngajatOficiu angajat = new model.AngajatOficiu(
                request.AngajatOficiu.Username,
                request.AngajatOficiu.Parola);
            return angajat;
        }
        public static ConcursResponse createOkResponse()
        {
            ConcursResponse response = new ConcursResponse{ Type=ConcursResponse.Types.Type.Ok};
            return response;
        }
        
        public static ConcursResponse createErrorResponse(String text)
        {
            ConcursResponse response = new ConcursResponse{
                Type=ConcursResponse.Types.Type.Error, Error=text};
            return response;
        }
        
        public static model.Inscriere getInscriere(ConcursRequest request){
            
            
            model.Inscriere inscriere=new model.Inscriere();

            model.Participant participant=new model.Participant();
            model.Proba proba=new model.Proba();
            Console.WriteLine(request);
            
            Console.WriteLine("GET INSCRIERE PROBA ID ---"+request.Inscriere.Proba.Id);
            
            proba.Id = request.Inscriere.Proba.Id;
            proba.Denumire = request.Inscriere.Proba.Denumire;
            proba.VarstaMin = Int32.Parse(request.Inscriere.Proba.VarstaMin);
            proba.VarstaMax = Int32.Parse(request.Inscriere.Proba.VarstaMax);


            participant.Id = request.Inscriere.Participant.Id;
            participant.Nume = request.Inscriere.Participant.Nume;
            participant.Prenume = request.Inscriere.Participant.Prenume;
            participant.Varsta = Int32.Parse(request.Inscriere.Participant.Varsta);

            inscriere.Proba = proba;
            inscriere.Participant = participant;
            inscriere.Id = request.Inscriere.Id;
           
          
            return inscriere;
        }
        public static model.Proba getProba (ConcursRequest request){

            model.Proba proba=new model.Proba( );
            proba.Id=request.Proba.Id;
            proba.Denumire=request.Proba.Denumire;
            proba.VarstaMin=Int32.Parse(request.Proba.VarstaMin);
            proba.VarstaMax=Int32.Parse(request.Proba.VarstaMax);
            
           

            return proba;
        }
        
        public static ConcursResponse createCautaParticipantiResponse(List<model.Participant>participants){
            ConcursResponse response = new ConcursResponse {
                Type = ConcursResponse.Types.Type.ParticipantiGasiti};

            foreach(model.Participant p in participants){
                proto.Participant participant = new proto.Participant
                {
                    Nume = p.Nume,
                    Prenume = p.Prenume,
                    Varsta = p.Varsta.ToString(),
                    
                    Id = p.Id
                };
                
                response.Participanti.Add(participant);
            }
            return response;
        }
        
        //GOT PROBE RESPONSE
        public static ConcursResponse createGetToateProbeResponse(List<model.Proba> probaList ){


          
            ConcursResponse response = new ConcursResponse {Type = ConcursResponse.Types.Type.GotProbe};
            foreach(model.Proba p in probaList){
                
                proto.Proba proba = new proto.Proba
                {
                    Denumire =p.Denumire,
                    VarstaMin = p.VarstaMin.ToString(),
                    VarstaMax = p.VarstaMax.ToString(),
                    Id=p.Id
                    
                };
                
                response.Proba.Add(proba);
            }

            return response;
        }
        public static ConcursResponse createGetToateProbeDTOResponse(List<model.ProbaDTO> probaList ){


          
            ConcursResponse response = new ConcursResponse {Type = ConcursResponse.Types.Type.GotProbeDto};
            foreach(model.ProbaDTO p in probaList){
                
                proto.ProbaDTO proba = new proto.ProbaDTO()
                {
                    Denumire =p.Denumire,
                    VarstaMin = p.VarstaMin.ToString(),
                    VarstaMax = p.VarstaMax.ToString(),
                    NrParticipanti = p.nrParticipanti.ToString(),
                    
                    Id=p.Id
                    
                };
                
                response.ProbaDTO.Add(proba);
            }

            return response;
        }



        public static ConcursResponse createInscriereRealizataResponse(model.Inscriere inscriere)
        {
            proto.Participant participantProto = new proto.Participant
            {
                Nume = inscriere.Participant.Nume,
                Prenume = inscriere.Participant.Prenume,
                Id = inscriere.Participant.Id,
                Varsta = inscriere.Participant.Varsta.ToString()
            };

            proto.Proba probaProto = new proto.Proba
            {
                Denumire = inscriere.Proba.Denumire,
                Id = inscriere.Proba.Id,
                VarstaMax = inscriere.Proba.VarstaMax.ToString(),
                VarstaMin = inscriere.Proba.VarstaMin.ToString()
            };

            proto.Inscriere inscriere2 = new proto.Inscriere
            {
                Participant = participantProto,
                Id = inscriere.Id,
                Proba = probaProto
            };
            ConcursResponse response = new ConcursResponse
            {
                Type = ConcursResponse.Types.Type.InscriereRealizata,
                Inscriere = inscriere2
            };
            return response;


        }
    }
    
    
    
    
}