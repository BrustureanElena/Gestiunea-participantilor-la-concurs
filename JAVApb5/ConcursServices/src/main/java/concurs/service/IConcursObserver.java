package concurs.service;

import concurs.domain.Inscriere;

public interface IConcursObserver {
    void inscriereUpdated(Inscriere inscriere)throws  ConcursException ;
}
