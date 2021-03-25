package repository;

import java.sql.SQLException;

public interface CrudRepository<ID, T> {
    void add(T elem);
    Iterable<T> findAll() throws SQLException;
// sa declar si update si delete
    void update(T elem, ID id);
}