using CSharp.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.repository
{
    interface IParticipantRepository: ICrudRepository<long,Participant>
    {
        Participant FindOne(long id);
      int GetNrParticipantiProbaVarsta(Proba proba);
      List<Participant> GetParticipantiProbaVarsta(Proba proba);
      Participant FindOneByNumePrenume(String nume,String prenume);




    }
}
