using System.Collections.Generic;
using CSharp.domain;

namespace CSharp.repository
{
    interface IInscriereRepository : ICrudRepository<long, Inscriere>
    {
     List<Inscriere> FindAll();
    }
}