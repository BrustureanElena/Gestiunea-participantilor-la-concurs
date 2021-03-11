using System.Collections.Generic;
using CSharp.domain;
using log4net;
namespace CSharp.repository
{
    public class ProbaDBRepository:IProbaRepository
    {
        private static readonly ILog log = LogManager.GetLogger("ParticipantDBRepository");
        public void Add(Proba elem)
        {
            throw new System.NotImplementedException();
        }

        public List<Proba> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public List<Proba> findAllByDenumire(string denumire1)
        {
            throw new System.NotImplementedException();
        }

        public List<Proba> findAll()
        {
            throw new System.NotImplementedException();
        }

        public Proba findOne(long aLong)
        {
            throw new System.NotImplementedException();
        }

        public Proba findOneByDenumire(string denumire1)
        {
            throw new System.NotImplementedException();
        }
    }
}