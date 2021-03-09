package concurs.repository;

public interface CrudRepository<ID, T> {
    void add(T elem);
    Iterable<T> findAll();
    T findOne(ID id);
}