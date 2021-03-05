package concurs.repository;

import concurs.domain.AngajatOficiu;

import java.util.List;

public interface IRepositoryAngajatOficiu {
   public AngajatOficiu add(AngajatOficiu e);
   public AngajatOficiu delete(AngajatOficiu e);
   public AngajatOficiu update(AngajatOficiu e);
   public AngajatOficiu findOne(Long id);
   public List<AngajatOficiu> findAll();
}
