using CSharp.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.repository
{
    public interface IProbaRepository: ICrudRepository<long,Proba>
    {
        List<Proba> findAllByDenumire(String denumire1);

        Proba FindOne(long aLong);

       Proba findOneByDenumireVarsta(String denumire, int varstaMin, int varstaMax);
    }
}
