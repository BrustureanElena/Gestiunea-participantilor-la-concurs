using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using model;


namespace services
{
    public interface IConcursObserver
    {
        void inscriereUpdated(Inscriere inscriere);

    }
}
