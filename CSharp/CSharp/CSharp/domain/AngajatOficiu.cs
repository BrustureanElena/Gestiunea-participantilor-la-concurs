using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.domain
{
    class AngajatOficiu:Entity<long>
    {
        private String Username { get; set; }
        private String Parola { get; set; }

        private AngajatOficiu(String Username, String Parola)
        {
            Username = Username;
            Parola = Parola;
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
            return base.ToString();
        }
    }
}
