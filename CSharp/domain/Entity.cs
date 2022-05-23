using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.domain
{
   interface Entity<TID>
    {

        TID Id { get; set; }


    }
}
