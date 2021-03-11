package concurs.repository;

import concurs.domain.Participant;
import concurs.domain.Proba;

import java.util.List;

public interface ProbaRepository extends CrudRepository<Long, Proba> {

    public Iterable<Proba> findAllByDenumire(String denumire1);

    public Iterable<Proba> findAll();

    public Proba findOne(Long aLong);

    public Proba findOneByDenumire(String denumire1);

}
