using CSharp.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.repository
{
    interface IRepositoryProba
    {
        Proba Add(Proba e);
        Proba Delete(Proba e);
        Proba Update(Proba e);
        Proba FindOne(long id);
        List<Proba> FindAll();
    }
}
