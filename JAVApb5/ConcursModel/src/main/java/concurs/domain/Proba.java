package concurs.domain;

import java.io.Serializable;
import java.util.Objects;

public class Proba  implements Entity<Long>, Serializable {
    private long id;
    private String denumire;
    private int varstaMin;
    private int varstaMax;

    public Proba() {

    }

    public Proba(String denumire,  int varstaMin, int varstaMax) {
        this.denumire = denumire;

        this.varstaMin = varstaMin;
        this.varstaMax = varstaMax;
    }

    public String getDenumire() {
        return denumire;
    }

    public void setDenumire(String denumire) {
        this.denumire = denumire;
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
        return id == proba.id &&
                varstaMin == proba.varstaMin &&
                varstaMax == proba.varstaMax &&
                Objects.equals(denumire, proba.denumire);
    }

    @Override
    public int hashCode() {
        return Objects.hash(denumire,varstaMin, varstaMax);
    }

    @Override
    public String toString() {
        return "Proba{" +
                "denumire='" + denumire + '\'' +

                ", varstaMin=" + varstaMin +
                ", varstaMax=" + varstaMax +
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
