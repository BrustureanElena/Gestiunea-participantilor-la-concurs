package repository;

import concurs.domain.AngajatOficiu;

public interface AngajatOficiuRepository extends CrudRepository<Long, AngajatOficiu>{
    public AngajatOficiu findOneByUsername(String username);
}
