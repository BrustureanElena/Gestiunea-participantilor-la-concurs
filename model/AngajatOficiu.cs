using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace model
{   	[Serializable]
    public class AngajatOficiu : Entity<long>
    { 
        public  long Id { get; set; }
        public String Username { get; set; }
        public String Parola { get; set; }

        public AngajatOficiu(String username, String parola)
        {
            Username = username;
            Parola = parola;
        }
        public AngajatOficiu()
        { }
        public override bool Equals(object obj)
        {
            return obj is AngajatOficiu oficiu &&
                   Username == oficiu.Username &&
                   Parola == oficiu.Parola;
        }
   

        public override int GetHashCode()
        {
            int hashCode = 326650367;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Parola);
            return hashCode;
        }

        public override string ToString()
        {
            return string.Format("[Angajat: Id={0}, Username={1},Parola={2}]", Id, Username, Parola);
        }


   
    }
}
