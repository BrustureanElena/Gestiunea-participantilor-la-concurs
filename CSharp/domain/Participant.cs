using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.domain
{
    public class Participant:Entity<long>
    {   public  long Id { get; set; }
        public String Nume { get; set; }
        public String Prenume { get; set; }
        public int Varsta { get; set; }
        
    
        public Participant(string nume, string prenume, int varsta)
        {
            Nume = nume;
            Prenume = prenume;
            Varsta = varsta;
        }
     public Participant(){}
        public override bool Equals(object obj)
        {
            return obj is Participant participant &&
                   Nume == participant.Nume &&
                   Prenume == participant.Prenume &&
                   Varsta == participant.Varsta;
        }

        /*public override int GetHashCode()
        {
            return base.GetHashCode();
        }
*/
        public override string ToString()
        {
            return string.Format("[Participant: Id={0}, Nume={1},Prenume={2},Varsta={3}]", Id, Nume,Prenume,Varsta);
        }
       
    }
}
