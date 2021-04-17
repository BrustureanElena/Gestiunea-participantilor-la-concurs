package concurs.domain;

import java.io.Serializable;
import java.util.Objects;

public class Participant implements Entity<Long>, Serializable {
    private long id;
    private String nume;
    private String prenume;
    private int varsta;
    public Participant() {

    }
    public Participant(String nume, String prenume, int varsta) {
        this.nume = nume;
        this.prenume = prenume;
        this.varsta = varsta;
    }

    public String getNume() {
        return nume;
    }

    public void setNume(String nume) {
        this.nume = nume;
    }

    public String getPrenume() {
        return prenume;
    }

    public void setPrenume(String prenume) {
        this.prenume = prenume;
    }

    public int getVarsta() {
        return varsta;
    }

    public void setVarsta(int varsta) {
        this.varsta = varsta;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Participant that = (Participant) o;
        return varsta == that.varsta &&
                Objects.equals(nume, that.nume) &&
                Objects.equals(prenume, that.prenume);
    }

    @Override
    public int hashCode() {
        return Objects.hash(nume, prenume, varsta);
    }

    @Override
    public String toString() {
        return "Participant{" +
                "id"+id+
                "nume='" + nume + '\'' +
                ", prenume='" + prenume + '\'' +
                ", varsta=" + varsta +
                '}';
    }

    @Override
    public Long getId() {
       return id;
    }

    @Override
    public void setId(Long id) {
    this.id=id;
    }
}
