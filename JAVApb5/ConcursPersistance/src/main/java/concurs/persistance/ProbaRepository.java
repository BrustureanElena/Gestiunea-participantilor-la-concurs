package concurs.persistance;

import concurs.domain.Proba;

public interface ProbaRepository extends CrudRepository<Long, Proba> {

    public Iterable<Proba> findAllByDenumire(String denumire1);

    public Iterable<Proba> findAll();

    public Proba findOne(Long aLong);

    public Proba findOneByDenumireVarsta(String denumire, int varstaMin, int varstaMax);



}
