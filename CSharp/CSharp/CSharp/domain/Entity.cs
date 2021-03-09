using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.domain
{
    class Entity<TID>
    {

        public TID Id { get; set; }

        public Entity(TID id)
        {
            Id = id;
        }
        public Entity() { }
    }
}
