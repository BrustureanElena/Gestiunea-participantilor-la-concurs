package concurs.domain;

import java.io.Serializable;

public class ProbaDTO extends  Proba implements Serializable {
    private int nrParticipanti;


    public ProbaDTO(String denumire, int varstaMin, int varstaMax,int nrParticipanti) {
        super(denumire, varstaMin, varstaMax);
        this.nrParticipanti=nrParticipanti;
    }

    @Override
    public String toString() {
        return "ProbaDTO{" +super.toString()+
                "nrParticipanti=" + nrParticipanti +
                '}';
    }

    public int getNrParticipanti() {
        return nrParticipanti;
    }

    public void setNrParticipanti(int nrParticipanti) {
        this.nrParticipanti = nrParticipanti;
    }
}
