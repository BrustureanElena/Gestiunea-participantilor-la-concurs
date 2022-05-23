namespace CSharp.domain
{
    public class Inscriere:Entity<long>
    {
        public long Id { get; set; }
        public Participant Participant { get; set; }
        public Proba Proba { get; set; }

        public Inscriere(Participant participant, Proba proba)
        {
            Participant = participant;
            Proba = proba;
        }
        
        public override string ToString()
        {
            return string.Format("[Inscriere: Id={0}, idParticipant={1},idProba={2}]", Id, Participant,Proba);
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