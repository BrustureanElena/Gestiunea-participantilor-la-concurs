using System;
using model;


namespace networking
{
    public interface Response
    {
        
    }
    [Serializable]
    public class OkResponse : Response
    {
		
    }
    [Serializable]
    public class ErrorResponse : Response
    {
        private string message;

        public ErrorResponse(string message)
        {
            this.message = message;
        }

        public virtual string Message
        {
            get
            {
                return message;
            }
        }
        

    }
    public interface UpdateResponse : Response
    {
        
    }
    
    [Serializable]
    public class AddInscriereResponse : UpdateResponse
    {
        private Inscriere inscriere;

        public AddInscriereResponse(Inscriere inscriere)
        {
            this.inscriere = inscriere;
        }

        public virtual Inscriere Inscriere
        {
            get
            {
                return inscriere;
            }
        }
    }
    
    [Serializable]
    public class GetToateProbeleResponse : Response
    {

        private Proba[] probe;
        public GetToateProbeleResponse(Proba[] probe)
        {
            this.probe = probe;
        }
        public virtual Proba[] Probe
        {
            get
            {
                return probe;
            }
        }
       
    }
    
    [Serializable]
    public class GetToateProbeleDTOResponse : Response
    {

        private ProbaDTO[] probeDTO;
        public GetToateProbeleDTOResponse(ProbaDTO[] probeDTO)
        {
            this.probeDTO = probeDTO;
        }
        public virtual ProbaDTO[] ProbeDTO
        {
            get
            {
                return probeDTO;
            }
        }
       
    }
    
    [Serializable]
    public class GetParticipantiProbaVarstaResponse : Response
    {
        private Participant[] participanti;
        
        public GetParticipantiProbaVarstaResponse(Participant[] participanti)
        {
            this.participanti = participanti;
        }
        public virtual Participant[] ParticipantiDTO
        {
            get
            {
                return participanti;
            }
        }

       
    }
    
    [Serializable]
    public class GetProbaResponse : Response
    {
        private Proba proba;
        
        public GetProbaResponse(Proba proba)
        {
            this.proba = proba;
        }
        public virtual Proba Proba
        {
            get
            {
                return proba;
            }
        }

       
    }
 

    
}