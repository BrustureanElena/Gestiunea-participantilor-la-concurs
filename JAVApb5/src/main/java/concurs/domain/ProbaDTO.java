package concurs.domain;

public class ProbaDTO extends  Proba{
    private int nrParticipanti;


    public ProbaDTO(String denumire, int varstaMin, int varstaMax,int nrParticipanti) {
        super(denumire, varstaMin, varstaMax);
        this.nrParticipanti=nrParticipanti;
    }

    public int getNrParticipanti() {
        return nrParticipanti;
    }

    public void setNrParticipanti(int nrParticipanti) {
        this.nrParticipanti = nrParticipanti;
    }
}
