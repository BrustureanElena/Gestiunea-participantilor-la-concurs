namespace CSharp.domain
{
    public class Inscriere:Entity<long>
    {
        public long Id { get; set; }
        private Participant Participant { get; set; }
        private Proba Proba { get; set; }

        public Inscriere(Participant participant, Proba proba)
        {
            Participant = participant;
            Proba = proba;
        }
        

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}