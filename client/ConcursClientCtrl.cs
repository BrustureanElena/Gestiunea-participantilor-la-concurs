using System;
using System.Collections.Generic;
using model;
using services;


namespace client
{
    public class ConcursClientCtrl:IConcursObserver
    {
        public event EventHandler<ConcursEventArgs> updateEvent; //ctrl calls it when it has received an update
        private readonly IConcursServices server;
        private AngajatOficiu currentUser;

        public ConcursClientCtrl(IConcursServices server)
        {
            this.server = server;
            currentUser = null;
        }

        public void inscriereUpdated(Inscriere inscriere)
        {
            Console.WriteLine("UPDATE: Add inregistrare" + inscriere);
            ConcursEventArgs inregistrareArgs = new ConcursEventArgs(ConcursEvent.AddInscriere, inscriere);
            OnConcursEvent(inregistrareArgs);
        }
        
      
        public void login(String userId, String pass)
        {
            AngajatOficiu user=new AngajatOficiu(userId,pass);
            server.login(user,this);
            Console.WriteLine("Login succeeded ....");
            currentUser = user;
            Console.WriteLine("Current user {0}", user);
        }
        
        public void logout()
        {
            Console.WriteLine("Ctrl logout");
            server.logout(currentUser, this);
            currentUser = null;
        }
        protected virtual void OnConcursEvent(ConcursEventArgs e)
        {
            if (updateEvent == null) return;
            updateEvent(this, e);
            Console.WriteLine("Update Event called");
        }

        public List<ProbaDTO> getToateProbeleDTO()
        {
            return server.getToateProbeleDTO();
        }
        public IEnumerable<Proba> getToateProbele()
        {
            return server.getToateProbele();
        }
        public IEnumerable<Participant> getParticipantiProbaVarsta(Proba proba)
        {
            return server.getParticipantiProbaVarsta(proba);
        }

        public Proba getProba(long idP)
        {
            return server.GetProba(idP);
        }
        public void addInscriere(Inscriere inscriere)
        {
            server.addInscriere(inscriere);
        }
       
    }
}