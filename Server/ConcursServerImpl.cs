using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using System.Threading.Tasks;
using model;
using persistence;
using services;

namespace Server
{
    public class ConcursServerImpl:IConcursServices
    {
        private IParticipantRepository participantiDBRepository;
        private IProbaRepository probaDBRepository;
        private IInscriereRepository inscriereDBRepository;
        private IAngajatOficiuRepository angajatiOficiuDBRepository;
        private readonly IDictionary<long, IConcursObserver> angajatiLogati;

        public ConcursServerImpl(IParticipantRepository participantiDbRepository, IProbaRepository probaDbRepository, IInscriereRepository inscriereDbRepository, IAngajatOficiuRepository angajatiOficiuDbRepository)
        {
            participantiDBRepository = participantiDbRepository;
            probaDBRepository = probaDbRepository;
            inscriereDBRepository = inscriereDbRepository;
            angajatiOficiuDBRepository = angajatiOficiuDbRepository;
            angajatiLogati=new Dictionary<long, IConcursObserver>();
        }

        public void addParticipant(string nume, string prenume, int varsta)
        {
            Participant participant=new Participant(nume,prenume,varsta);
            participantiDBRepository.Add(participant);
        }

        public void addInscriere(Inscriere inscriere)
        {
            Participant participant=participantiDBRepository.AddWithReturn(inscriere.Participant);
        
            try {
                inscriere.Participant=participant;
                inscriereDBRepository.Add(inscriere);
             
                notifyAddedInscriere(inscriere);
            }catch (Exception e) {
                throw  new ConcursException(e.Message);
            }
          
            
        }

        public void login(AngajatOficiu angajatOficiu, IConcursObserver obs)
        {
            AngajatOficiu angajatOficiu1=angajatiOficiuDBRepository.findOneByUsername(angajatOficiu.Username);

           
            if(angajatOficiu1 != null) {
                if(angajatiLogati.ContainsKey(angajatOficiu1.Id))
                    throw new ConcursException("User already logged in.");
               
            //    angajatiLogati[angajatOficiu1.Id] = obs;
                //aici oare ii add?
                angajatiLogati.Add(angajatOficiu1.Id,obs);
                //lavi
              // angajatiLogati[angajatOficiu1.Id] = obs;
            }else{
                throw new ConcursException("Autentificare esuata!");
            }
        }

        public AngajatOficiu getConnectedUser()
        {
            throw new System.NotImplementedException();
        }

        public void logout(AngajatOficiu angajatOficiu, IConcursObserver obs)
        {
            angajatiLogati.Remove(angajatOficiu.Id);
        }

        public int getNrInscrisiProba(Proba proba)
        {
            return participantiDBRepository.GetNrParticipantiProbaVarsta(proba);
        }

        public IEnumerable<Proba> getToateProbele()
        {
            return probaDBRepository.FindAll();
        }

        public List<ProbaDTO> getToateProbeleDTO()
        {
            List<Proba> probe= (List<Proba>) probaDBRepository.FindAll();
            //Console.WriteLine("find all "+probe);
            List<ProbaDTO> probaDTOS = new List<ProbaDTO>();
           
            foreach (Proba proba in probe)
            {
                ProbaDTO probaDTO=new ProbaDTO(proba.Denumire,proba.VarstaMin,proba.VarstaMax,getNrInscrisiProba(proba));
                //  probaDTO.setId(proba.getId());
               // Console.WriteLine(probaDTO);
                probaDTO.Id=proba.Id;
                probaDTOS.Add(probaDTO);
              //  Console.WriteLine(probaDTO);
            }
            
            return probaDTOS;
        }

        public IEnumerable<Participant> getTotiParticipantii()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Participant> getParticipantiProbaVarsta(Proba proba)
        {
            IEnumerable<Participant>participantList=participantiDBRepository.GetParticipantiProbaVarsta(proba);
            return (IEnumerable<Participant>) participantList;
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
        {
            return probaDBRepository.FindOne(idP);
        }

        public void notifyAddedInscriere(Inscriere inscriere)
        {
            foreach (KeyValuePair<long, IConcursObserver> pair in angajatiLogati)
            {
                
                Task.Run(() => pair.Value.inscriereUpdated(inscriere));
            }
        }
        
      
    }
}