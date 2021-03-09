using CSharp.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.validator
{
    interface IValidator<E> where E:Entity<long>
    {
        void Validate(E e);
    }
}
