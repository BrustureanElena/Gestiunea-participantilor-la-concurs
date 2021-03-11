using System.Collections.Generic;
using CSharp.domain;

using log4net;
namespace CSharp.repository
{
    public class ParticipantDBRepository:IParticipantRepository
    {
        
        private static readonly ILog log = LogManager.GetLogger("ParticipantDBRepository");
        public void Add(Participant elem)
        {
            throw new System.NotImplementedException();
        }

        public List<Participant> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Participant FindOne(long id)
        {
            throw new System.NotImplementedException();
        }

        public int GetNrParticipantiProbaVarsta(Proba proba)
        {
            throw new System.NotImplementedException();
        }

        public List<Participant> getParticipantiProbaVarsta(Proba proba)
        {
            throw new System.NotImplementedException();
        }

        public Participant FindOneByNumePrenume(string nume, string prenume)
        {
            throw new System.NotImplementedException();
        }
    }
}