using System;
using System.Collections.Generic;
using CSharp.domain;
using CSharp.repository;
using CSharp.utils;

namespace CSharp.service
{
    public class Service
    {
        private AngajatOficiu connectedUser;
        private ParticipantDBRepository participantiDBRepository;
        private ProbaDBRepository probaDBRepository;
        private InscriereDBRepository inscriereDBRepository;
        private AngajatOficiuDBRepository angajatiOficiuDBRepository;

        
        //aici trebuie si cu connectedUser?
        public Service(ParticipantDBRepository participantiDbRepository, ProbaDBRepository probaDbRepository, InscriereDBRepository inscriereDbRepository, AngajatOficiuDBRepository angajatiOficiuDbRepository)
        {
            participantiDBRepository = participantiDbRepository;
            probaDBRepository = probaDbRepository;
            inscriereDBRepository = inscriereDbRepository;
            angajatiOficiuDBRepository = angajatiOficiuDbRepository;
        }

        public long addParticipant( String nume, String prenume, int varsta) {

            Participant participant=new Participant(nume,prenume,varsta);
            participantiDBRepository.Add(participant);
            return participant.Id;
        }

        public void addInscriere(String nume,String prenume,int varsta,Proba proba) {

            Participant participant=participantiDBRepository.findOneByNumePrenume2(nume,prenume);
            if(participant==null)
                {
                addParticipant(nume,prenume,varsta);
                participant=participantiDBRepository.findOneByNumePrenume2(nume,prenume);
                }

            Inscriere inscriere=new Inscriere(participant,proba);

          
                inscriereDBRepository.Add(inscriere);
            
        }
        
        public void login(String username, String password) {
            AngajatOficiu angajatOficiu=angajatiOficiuDBRepository.findOneByUsername(username);
        if(angajatOficiu==null)
        throw new MyException("There is no user with tis username:\n");
            if(!angajatOficiu.Parola.Equals(password))
            throw new MyException("Incorrect password!\n");


        connectedUser=angajatOficiu;


    }

    public AngajatOficiu getConnectedUser(){return connectedUser;}
        
    public  void logout(){
        connectedUser=null;
    }

    public int getNrInscrisiProba(Proba proba)
    {
        return participantiDBRepository.GetNrParticipantiProbaVarsta(proba);
    }
    
    public IEnumerable<Proba>getToateProbele() {
        return probaDBRepository.FindAll();
    }
    
    public IEnumerable<ProbaDTO>getToateProbeleDTO() {
        List<Proba> probe= (List<Proba>) probaDBRepository.FindAll();
        List<ProbaDTO> probaDTOS = new List<ProbaDTO>();
    
        foreach (Proba proba in probe)
        {
            ProbaDTO probaDTO=new ProbaDTO(proba.Denumire,proba.VarstaMin,proba.VarstaMax,getNrInscrisiProba(proba));
          //  probaDTO.setId(proba.getId());
            
            probaDTO.Id=proba.Id;
            probaDTOS.Add(probaDTO);
        }
   
        return probaDTOS;

    }
    
    public IEnumerable<Participant>getTotiParticipantii() {
        return participantiDBRepository.FindAll();
    }
    
    public IEnumerable<Participant> getParticipantiProbaVarsta(Proba proba)
    {

        IEnumerable<Participant>participantList=participantiDBRepository.GetParticipantiProbaVarsta(proba);
        return (IEnumerable<Participant>) participantList;
    }
    
    public Participant findOneByNumePrenume(String numeDat, String prenumeDat){
        return participantiDBRepository.findOneByNumePrenume2(numeDat, prenumeDat);
    }
    public Proba findOneByDenumireVarsta(String denumire, int varstaMin, int varstaMax){
        return probaDBRepository.findOneByDenumireVarsta(denumire, varstaMin, varstaMax);
    }
    
    
    
    }
}