using CSharp.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.repository
{
    interface IRepositoryAngajatOficiu
    {

         AngajatOficiu Add(AngajatOficiu e);
         AngajatOficiu Delete(AngajatOficiu e);
         AngajatOficiu Update(AngajatOficiu e);
         AngajatOficiu FindOne(long id);
         List<AngajatOficiu> FindAll();
    }
}
