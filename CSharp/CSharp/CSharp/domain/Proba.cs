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
        public String Denumire { get; set; }

        public int VarstaMin { get; set; }
        public int VarstaMax { get; set; }

        public Proba(string denumire,int varstaMin, int varstaMax)
        {
            Denumire = denumire;
       
            VarstaMin = varstaMin;
            VarstaMax = varstaMax;
        }
        public Proba()
        { }
        public override bool Equals(object obj)
        {
            return obj is Proba proba &&
                   Denumire == proba.Denumire &&
                
                   VarstaMin == proba.VarstaMin &&
                   VarstaMax == proba.VarstaMax;
        }

        public override int GetHashCode()
        {
            int hashCode = 1248040347;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Denumire);

            hashCode = hashCode * -1521134295 + VarstaMin.GetHashCode();
            hashCode = hashCode * -1521134295 + VarstaMax.GetHashCode();
            return hashCode;
        }

    
        public override string ToString()
        {
            return string.Format("[Proba: Id={0}, Denumire={1},VarstaMin={2},VarstaMax={3}]", Id, Denumire,VarstaMin,VarstaMax);
        }
    
    }
}
