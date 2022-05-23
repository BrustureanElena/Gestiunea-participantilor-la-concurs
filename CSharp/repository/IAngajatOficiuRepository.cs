using CSharp.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.repository
{
  public   interface IAngajatOficiuRepository:ICrudRepository<long,AngajatOficiu>
    {

        AngajatOficiu findOneByUsername(string username);
    }
}
