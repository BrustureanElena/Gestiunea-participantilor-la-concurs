using System.Collections.Generic;
using CSharp.domain;
using log4net;
namespace CSharp.repository
{
    public class InscriereDBRepository:IInscriereRepository
    {
        private static readonly ILog log = LogManager.GetLogger("ParticipantDBRepository");
        public void Add(Inscriere elem)
        {
            throw new System.NotImplementedException();
        }

        List<Inscriere> IInscriereRepository.FindAll()
        {
            throw new System.NotImplementedException();
        }

        List<Inscriere> ICrudRepository<long, Inscriere>.FindAll()
        {
            throw new System.NotImplementedException();
        }
    }
}