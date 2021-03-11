using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.domain
{
    public class Participant:Entity<long>
    {   public  long Id { get; set; }
        private String nume;
        private String prenume;
        private int varsta;
        public string Nume { 
            get { return nume; } 
            set {nume = value; } 
        }
        public string Prenume { 
            get { return prenume; } 
            set {prenume = value; } 
        }
        public int Varsta
        {
            get { return varsta; } 
            set {varsta = value; } 
        }
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
            return string.Format("[Participant: Id={0}, Nume={1},Prenume={2},Varsta={3}]", Id, Nume,Prenume,Varsta);
        }
       
    }
}
