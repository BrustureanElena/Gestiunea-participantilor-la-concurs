package concurs.repository;

import java.sql.SQLException;

public interface CrudRepository<ID, T> {
    void add(T elem);
    Iterable<T> findAll() throws SQLException;

}