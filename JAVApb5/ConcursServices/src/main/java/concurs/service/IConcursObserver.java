package concurs.service;

import concurs.domain.Inscriere;

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface IConcursObserver extends Remote {
    void inscriereUpdated(Inscriere inscriere)throws  ConcursException , RemoteException;
}
