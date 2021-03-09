package concurs.repository;

import concurs.domain.Inscriere;
import concurs.domain.Participant;
import concurs.domain.Proba;

import java.util.List;

public interface InscriereRepository extends CrudRepository<Long, Inscriere> {

    int getNrParticipantiProba(Proba proba);

    List<Participant> getParticipantiProba(Proba proba);
}
