using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.domain
{
    public class Participant:Entity<long>
    {   public  long Id { get; set; }
        private String Nume { get; set; }
        private String Prenume { get; set; }
        private int Varsta { get; set; }

        public Participant(string nume, string prenume, int varsta)
        {
            Nume = nume;
            Prenume = prenume;
            Varsta = varsta;
        }
        public Participant()
        { }
        public override bool Equals(object obj)
        {
            return obj is Participant participant &&
                   Nume == participant.Nume &&
                   Prenume == participant.Prenume &&
                   Varsta == participant.Varsta;
        }

        public override int GetHashCode()
        {
            int hashCode = -733072957;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nume);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Prenume);
            hashCode = hashCode * -1521134295 + Varsta.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }

       
    }
}
