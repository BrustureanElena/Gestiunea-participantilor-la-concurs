
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;


namespace persistence
{
  public   interface IAngajatOficiuRepository:ICrudRepository<long,AngajatOficiu>
    {

        AngajatOficiu findOneByUsername(string username);
    }
}
