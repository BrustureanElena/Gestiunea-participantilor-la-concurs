using System;

namespace model
{     [Serializable]
    public class ProbaDTO:Proba
    {
        public int nrParticipanti{ get; set; }

        public ProbaDTO(string denumire, int varstaMin, int varstaMax, int NrParticipanti) : base(denumire, varstaMin, varstaMax)
        {
            this.nrParticipanti = NrParticipanti;
        }

       /* public ProbaDTO(int NrParticipanti)
        {
            this.nrParticipanti = NrParticipanti;
        }*/

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
           // return base.ToString();
            return string.Format("[Proba: Id={0}, Denumire={1},VarstaMin={2},VarstaMax={3},nrParticipanti={4}]", Id, Denumire,VarstaMin,VarstaMax,nrParticipanti);
        }
    }
}