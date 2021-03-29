package repository;

import concurs.domain.Participant;
import concurs.domain.Proba;

public interface ParticipantRepository extends CrudRepository<Long,Participant>{

    public Participant findOne(Long aLong);
    public int getNrParticipantiProbaVarsta(Proba proba);
    public Participant addWithReturn(Participant elem);
    public Iterable<Participant> getParticipantiProbaVarsta(Proba proba);
   // public Participant findOneByNumePrenume(String nume,String prenume);
   public Participant findOneByNumePrenume(String numeDat, String prenumeDat);
}
