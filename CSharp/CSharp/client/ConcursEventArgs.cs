using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using model;

namespace client
{
    public enum ConcursEvent
    {
        AddInscriere
    } ;
    public class ConcursEventArgs : EventArgs
    {
        private readonly ConcursEvent concursEvent;
        private readonly Inscriere data;


        public ConcursEventArgs(ConcursEvent concursEvent, Inscriere data)
        {
            this.concursEvent = concursEvent;
            this.data = data;
        }

        public ConcursEvent ConcursEventType
        {
            get { return concursEvent; }
        }

        public Inscriere Data
        {
            get { return data; }
        }
    }
}
