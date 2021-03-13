using CSharp.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.repository
{
    interface IProbaRepository: ICrudRepository<long,Proba>
    {
        List<Proba> findAllByDenumire(String denumire1);

        Proba FindOne(long aLong);

      Proba findOneByDenumire(String denumire1);
    }
}
