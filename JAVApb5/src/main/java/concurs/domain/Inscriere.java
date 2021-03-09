package concurs.domain;

import java.util.Objects;

public class Inscriere implements Entity<Long>{
    private  Long id;
    private  Participant participant;
    private Proba proba;

    public Inscriere(Long id, Participant participant, Proba proba) {
        this.id = id;
        this.participant = participant;
        this.proba = proba;
    }

    public Participant getParticipant() {
        return participant;
    }

    public void setParticipant(Participant participant) {
        this.participant = participant;
    }

    public Proba getProba() {
        return proba;
    }

    public void setProba(Proba proba) {
        this.proba = proba;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Inscriere inscriere = (Inscriere) o;
        return Objects.equals(id, inscriere.id) &&
                Objects.equals(participant, inscriere.participant) &&
                Objects.equals(proba, inscriere.proba);
    }

    @Override
    public String toString() {
        return "Inscriere{" +
                "id=" + id +
                ", participant=" + participant +
                ", proba=" + proba +
                '}';
    }

    @Override
    public int hashCode() {
        return Objects.hash(id, participant, proba);
    }

    @Override
    public Long getId() {
        return null;
    }

    @Override
    public void setId(Long aLong) {

    }


}
