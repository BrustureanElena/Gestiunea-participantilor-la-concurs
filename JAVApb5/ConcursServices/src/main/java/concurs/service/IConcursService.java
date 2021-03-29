package concurs.service;

import concurs.domain.*;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public interface IConcursService {
    public void addParticipant( String nume, String prenume, int varsta) ;

    public void addInscriere(Inscriere inscriere) throws ConcursException;

    public void login(AngajatOficiu angajatOficiu,IConcursObserver obs) throws ConcursException;

    public void logout(AngajatOficiu angajatOficiuCurent,IConcursObserver client) throws ConcursException;






    int getNrInscrisiProba(Proba proba);
    public Iterable<Proba>getToateProbele() throws ConcursException;

    public Collection<ProbaDTO> getToateProbeleDTO() throws ConcursException;



    public Iterable<Participant>getTotiParticipantii() throws SQLException;

    public Collection<? extends Participant> getParticipantiProbaVarsta(Proba proba) throws  ConcursException;
    public Participant findOneByNumePrenume(String numeDat, String prenumeDat);
    public Proba findOneByDenumireVarsta(String denumire, int varstaMin, int varstaMax);
}
