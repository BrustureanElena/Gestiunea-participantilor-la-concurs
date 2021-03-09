using CSharp.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.repository
{
    interface IRepositoryParticipant
    {
        Participant Add(Participant e);
        Participant Delete(Participant e);
        Participant Update(Participant e);
        Participant FindOne(long id);
        List<Participant> FindAll();
    }
}
