package concurs.service;

import concurs.domain.*;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public interface IConcursService {
    public Long addParticipant( String nume, String prenume, int varsta) ;


    public void addInscriere(String nume, String prenume, int varsta, Proba proba) throws Exception;




    public void login(String username, String password) throws Exception;

    public AngajatOficiu getConnectedUser();

    public  void logout();


    int getNrInscrisiProba(Proba proba);
    public Iterable<Proba>getToateProbele() ;

    public Collection<ProbaDTO> getToateProbeleDTO() ;



    public Iterable<Participant>getTotiParticipantii() throws SQLException;

    public Collection<? extends Participant> getParticipantiProbaVarsta(Proba proba);
    public Participant findOneByNumePrenume(String numeDat, String prenumeDat);
    public Proba findOneByDenumireVarsta(String denumire, int varstaMin, int varstaMax);
}
