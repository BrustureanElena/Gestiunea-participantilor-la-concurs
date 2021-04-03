using System;
using model;


namespace networking
{
    public interface Request
    {
        
    }
    
    [Serializable]
    public class LoginRequest : Request
    {
        private AngajatOficiu user;

        public LoginRequest(AngajatOficiu user)
        {
            this.user = user;
        }

        public virtual AngajatOficiu User
        {
            get
            {
                return user;
            }
        }
    }
    
    [Serializable]
    public class LogoutRequest : Request
    {
        private AngajatOficiu user;

        public LogoutRequest(AngajatOficiu user)
        {
            this.user = user;
        }

        public virtual AngajatOficiu User
        {
            get
            {
                return user;
            }
        }
    }
  
    
    [Serializable]
    public class GetToateProbeleRequest : Request
    {

        public GetToateProbeleRequest()
        {
        }
    }
      
    [Serializable]
    public class GetToateProbeleDTORequest : Request
    {

        public GetToateProbeleDTORequest()
        {
        }
    }
    
    [Serializable]
    public class GetProbaRequest : Request
    {
        private long idP;
        public  GetProbaRequest(long idP)
        {
            this.idP = idP;
        }

        public virtual long IdP
        {
            get
            {
                return idP;
            }
        }
    }
    [Serializable]
    public class GetParticipantiProbaVarstaRequest : Request
    {
        private Proba proba;
        public  GetParticipantiProbaVarstaRequest(Proba proba)
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
    [Serializable]
    public class AddInscriereRequest : Request
    {
        private Inscriere inscriere;

        public AddInscriereRequest(Inscriere inscriere)
        {
            this.inscriere= inscriere;
        }

        public virtual Inscriere Inscriere
        {
            get
            {
                return inscriere;
            }
        }
    }
    
  
    
}