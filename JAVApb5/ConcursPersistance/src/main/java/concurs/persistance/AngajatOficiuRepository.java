package concurs.persistance;

import concurs.domain.AngajatOficiu;

public interface AngajatOficiuRepository extends CrudRepository<Long, AngajatOficiu>{
    public AngajatOficiu findOneByUsername(String username,String parola);
    public boolean login(String username, String parola);
}
