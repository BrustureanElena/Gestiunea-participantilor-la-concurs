package concurs.repository;

import concurs.domain.AngajatOficiu;
import concurs.domain.Participant;

import java.util.List;

public interface AngajatOficiuRepository extends CrudRepository<Long, AngajatOficiu>{
    public AngajatOficiu findOneByUsername(String username);
}
