using System;
using System.Collections.Generic;
using model;


namespace services
{
    public interface IConcursServices
    {
        void addParticipant(String nume, String prenume, int varsta);

        void addInscriere(Inscriere inscriere);

        void login(AngajatOficiu angajatOficiu,IConcursObserver obs);

        AngajatOficiu getConnectedUser();

     void logout(AngajatOficiu angajatOficiu,IConcursObserver obs);

        int getNrInscrisiProba(Proba proba);

     IEnumerable<Proba> getToateProbele();

    List<ProbaDTO> getToateProbeleDTO();

    IEnumerable<Participant> getTotiParticipantii();
    IEnumerable<Participant> getParticipantiProbaVarsta(Proba proba);

   Participant findOneByNumePrenume(String numeDat, String prenumeDat);
     Proba findOneByDenumireVarsta(String denumire, int varstaMin, int varstaMax);

    Proba GetProba(long idP);


    }
}