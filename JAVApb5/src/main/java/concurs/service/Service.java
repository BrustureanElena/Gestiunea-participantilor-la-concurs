package concurs.service;

import concurs.domain.*;
import concurs.repository.*;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class Service {

    private AngajatOficiu connectedUser;
    private ParticipantRepository participantiDBRepository;
    private ProbaRepository probaDBRepository;
    private InscriereRepository inscriereDBRepository;
    private AngajatOficiuRepository angajatiOficiuDBRepository;

    public Service(ParticipantRepository participantiDBRepository, ProbaRepository probaDBRepository, InscriereRepository inscriereDBRepository, AngajatOficiuRepository angajatiOficiuDBRepository) {
        this.participantiDBRepository = participantiDBRepository;
        this.probaDBRepository = probaDBRepository;
        this.inscriereDBRepository = inscriereDBRepository;
        this.angajatiOficiuDBRepository = angajatiOficiuDBRepository;
    }

    //public Service(ParticipantiDBRepository participantiDBRepository, ProbaDBRepository probaDBRepository, InscriereDBRepository inscriereDBRepository, AngajatiOficiuDBRepository angajatiOficiuDBRepository) {
   //     this.participantiDBRepository = participantiDBRepository;
   //     this.probaDBRepository = probaDBRepository;
    //    this.inscriereDBRepository = inscriereDBRepository;
    //    this.angajatiOficiuDBRepository = angajatiOficiuDBRepository;
  //  }


    public void addParticipant( String nume, String prenume, int varsta) {

            Participant participant=new Participant(nume,prenume,varsta);
            participantiDBRepository.add(participant);
           // return participant.getId();
    }


    public void addInscriere(String nume,String prenume,int varsta,Proba proba) throws Exception {

        Participant participant=participantiDBRepository.findOneByNumePrenume(nume,prenume);
        if(participant==null)
        {
            addParticipant(nume,prenume,varsta);
            participant=participantiDBRepository.findOneByNumePrenume(nume,prenume);


        }

        Inscriere inscriere=new Inscriere(participant,proba);

       // proba.setNrParticipanti(proba.getNrParticipanti()+1);
       // probaDBRepository.update(proba, proba.getId());
        try {
            inscriereDBRepository.add(inscriere);
        }catch (Exception e) {
            throw  new Exception(e);
        }
    }


    public void login(String username, String password) throws Exception{
        AngajatOficiu angajatOficiu=angajatiOficiuDBRepository.findOneByUsername(username);
        if(angajatOficiu==null)
            throw new Exception("There is no user with tis username:\n");
        if(!angajatOficiu.getParola().equals(password))
            throw new Exception("Incorrect password!\n");
        connectedUser=angajatOficiu;


    }

    public AngajatOficiu getConnectedUser(){return connectedUser;}

    public  void logout(){
        connectedUser=null;
    }

    int getNrInscrisiProba(Proba proba){
        return participantiDBRepository.getNrParticipantiProbaVarsta(proba);
    }

    public Iterable<Proba>getToateProbele() {
        return probaDBRepository.findAll();
    }

    public Collection<ProbaDTO>getToateProbeleDTO() {
        List<Proba> probe= (List<Proba>) probaDBRepository.findAll();
        List<ProbaDTO>probaDTOS=new ArrayList<>();
        probe.forEach(proba -> {
            ProbaDTO probaDTO=new ProbaDTO(proba.getDenumire(),proba.getVarstaMin(),proba.getVarstaMax(),getNrInscrisiProba(proba));
            probaDTO.setId(proba.getId());
            probaDTOS.add(probaDTO);
        });
        return probaDTOS;

    }


    public Iterable<Participant>getTotiParticipantii() throws SQLException {
        return participantiDBRepository.findAll();
    }

    public Collection<? extends Participant> getParticipantiProbaVarsta(Proba proba)
    {

        Iterable<Participant>participantList=participantiDBRepository.getParticipantiProbaVarsta(proba);
        return (Collection<? extends Participant>) participantList;
    }

    public Participant findOneByNumePrenume(String numeDat, String prenumeDat){
        return participantiDBRepository.findOneByNumePrenume(numeDat, prenumeDat);
    }
    public Proba findOneByDenumireVarsta(String denumire, int varstaMin, int varstaMax){
        return probaDBRepository.findOneByDenumireVarsta(denumire, varstaMin, varstaMax);
    }
}
