package concurs.repository;

import concurs.domain.Proba;

import java.util.List;

public interface IRepositoryProba {
    public Proba add(Proba e);
    public Proba delete(Proba e);
    public Proba update(Proba e);
    public Proba findOne(Long id);
    public List<Proba> findAll();
}
