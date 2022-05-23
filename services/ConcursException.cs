using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace services
{
    public class ConcursException : Exception
    {
        public ConcursException():base() { }

        public ConcursException(String msg) : base(msg) { }

        public ConcursException(String msg, Exception ex) : base(msg, ex) { }

    }
}
