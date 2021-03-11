using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.domain
{
    public class Proba:Entity<long>
    {
        public  long Id { get; set; }
        private String Denumire { get; set; }
        private List<Participant> Participanti { get; set; }
        private int VarstaMin { get; set; }
        private int VarstaMax { get; set; }

        public Proba(string denumire, List<Participant> participanti, int varstaMin, int varstaMax)
        {
            Denumire = denumire;
            Participanti = participanti;
            VarstaMin = varstaMin;
            VarstaMax = varstaMax;
        }
        public Proba()
        { }
        public override bool Equals(object obj)
        {
            return obj is Proba proba &&
                   Denumire == proba.Denumire &&
                   EqualityComparer<List<Participant>>.Default.Equals(Participanti, proba.Participanti) &&
                   VarstaMin == proba.VarstaMin &&
                   VarstaMax == proba.VarstaMax;
        }

        public override int GetHashCode()
        {
            int hashCode = 1248040347;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Denumire);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Participant>>.Default.GetHashCode(Participanti);
            hashCode = hashCode * -1521134295 + VarstaMin.GetHashCode();
            hashCode = hashCode * -1521134295 + VarstaMax.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }

    
    }
}
