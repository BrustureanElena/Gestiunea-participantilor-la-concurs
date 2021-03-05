package concurs.domain;

import java.util.List;
import java.util.Objects;

public class Proba  extends Entity<Long>{
    private String denumire;
    private List<Participant> participanti;
    private int varstaMin;
    private int varstaMax;

    public Proba(String denumire, List<Participant> participanti, int varstaMin, int varstaMax) {
        this.denumire = denumire;
        this.participanti = participanti;
        this.varstaMin = varstaMin;
        this.varstaMax = varstaMax;
    }

    public String getDenumire() {
        return denumire;
    }

    public void setDenumire(String denumire) {
        this.denumire = denumire;
    }

    public List<Participant> getparticipanti() {
        return participanti;
    }

    public void setparticipanti(List<Participant> participanti) {
        this.participanti = participanti;
    }

    public int getVarstaMin() {
        return varstaMin;
    }

    public void setVarstaMin(int varstaMin) {
        this.varstaMin = varstaMin;
    }

    public int getVarstaMax() {
        return varstaMax;
    }

    public void setVarstaMax(int varstaMax) {
        this.varstaMax = varstaMax;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Proba proba = (Proba) o;
        return varstaMin == proba.varstaMin &&
                varstaMax == proba.varstaMax &&
                Objects.equals(denumire, proba.denumire) &&
                Objects.equals(participanti, proba.participanti);
    }

    @Override
    public int hashCode() {
        return Objects.hash(denumire, participanti, varstaMin, varstaMax);
    }

    @Override
    public String toString() {
        return "Proba{" +
                "denumire='" + denumire + '\'' +
                ", participanti=" + participanti +
                ", varstaMin=" + varstaMin +
                ", varstaMax=" + varstaMax +
                '}';
    }
}
