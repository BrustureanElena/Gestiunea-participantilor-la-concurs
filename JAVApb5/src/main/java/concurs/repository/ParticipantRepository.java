package concurs.repository;

import concurs.domain.Participant;
import concurs.domain.Proba;

import java.util.List;

public interface ParticipantRepository extends CrudRepository<Long,Participant>{

    public Participant findOne(Long aLong);
    public int getNrParticipantiProbaVarsta(Proba proba);

    public Iterable<Participant> getParticipantiProbaVarsta(Proba proba);
    public Participant findOneByNumePrenume(String nume,String prenume);
}
