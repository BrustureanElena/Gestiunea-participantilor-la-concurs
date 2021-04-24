package concurs.server;

import concurs.domain.*;
import concurs.service.ConcursException;
import concurs.service.IConcursObserver;
import concurs.service.IConcursService;
import concurs.persistance.AngajatOficiuRepository;
import concurs.persistance.InscriereRepository;
import concurs.persistance.ParticipantRepository;
import concurs.persistance.ProbaRepository;

import java.rmi.RemoteException;
import java.sql.SQLException;
import java.util.*;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class ServiceImplementation  implements IConcursService {

    private Map<Long,IConcursObserver>angajatiLogati;
    private ParticipantRepository participantiDBRepository;
    private ProbaRepository probaDBRepository;
    private InscriereRepository inscriereDBRepository;
    private AngajatOficiuRepository angajatiOficiuDBRepository;



    public ServiceImplementation(ParticipantRepository participantiDBRepository, ProbaRepository probaDBRepository, InscriereRepository inscriereDBRepository, AngajatOficiuRepository angajatiOficiuDBRepository) {
        this.participantiDBRepository = participantiDBRepository;
        this.probaDBRepository = probaDBRepository;
        this.inscriereDBRepository = inscriereDBRepository;
        this.angajatiOficiuDBRepository = angajatiOficiuDBRepository;
       // observers=new ArrayList<>();
        angajatiLogati=new ConcurrentHashMap<>();


    }

    //public Service(ParticipantiDBRepository participantiDBRepository, ProbaDBRepository probaDBRepository, InscriereDBRepository inscriereDBRepository, AngajatiOficiuDBRepository angajatiOficiuDBRepository) {
   //     this.participantiDBRepository = participantiDBRepository;
   //     this.probaDBRepository = probaDBRepository;
    //    this.inscriereDBRepository = inscriereDBRepository;
    //    this.angajatiOficiuDBRepository = angajatiOficiuDBRepository;
  //  }

    @Override
    public synchronized void addParticipant( String nume, String prenume, int varsta) {

            Participant participant=new Participant(nume,prenume,varsta);
            participantiDBRepository.add(participant);
            //return participant.getId();
    }
    @Override
    public synchronized void addInscriere(Inscriere inscriere) throws  ConcursException{

       // Participant participant=participantiDBRepository.findOneByNumePrenume(nume,prenume);
      //  if(participant==null)
       // {
          //  addParticipant(nume,prenume,varsta);
          //  participant=participantiDBRepository.findOneByNumePrenume(nume,prenume);
      //  }
        Participant participant=participantiDBRepository.addWithReturn(inscriere.getParticipant());
       // Inscriere inscriere=new Inscriere(participant,proba);

       // proba.setNrParticipanti(proba.getNrParticipanti()+1);
       // probaDBRepository.update(proba, proba.getId());
        try {
            inscriere.setParticipant(participant);
            inscriereDBRepository.add(inscriere);
            notifyInscriereUpdated(inscriere);
        }catch (Exception e) {
            throw  new ConcursException(e.getMessage());
        }

    }


    @Override
    public synchronized void login(AngajatOficiu angajatOficiu,IConcursObserver obs) throws ConcursException {
        AngajatOficiu angajatOficiu1=angajatiOficiuDBRepository.findOneByUsername(angajatOficiu.getUsername(),angajatOficiu.getParola());

      //  AngajatOficiu organizatorR = angajatiOficiuDBRepository.findOrganizatorByUsernameParola(organizator.getUsername(),organizator.getParola());
        if(angajatOficiu1 != null) {
            if(angajatiLogati.get(angajatOficiu1.getId()) != null){
                throw new ConcursException("Organizatorul deja s-a logat!");
            }
            //retin in dictionar, cheie-id, valoare-referinta catre ConcursClientWorker
            angajatiLogati.put(angajatOficiu1.getId(),obs);
        }else{
            throw new ConcursException("Autentificare esuata!");
        }
    }


//DUMINICA, OARE II OK LOGOUTUL
    @Override
    public void logout(AngajatOficiu angajatOficiuCurent,IConcursObserver client) throws ConcursException {
        angajatiLogati.remove(angajatOficiuCurent);
    }
    @Override
    public synchronized int getNrInscrisiProba(Proba proba){
        return participantiDBRepository.getNrParticipantiProbaVarsta(proba);
    }
    @Override
    public synchronized Iterable<Proba>getToateProbele() {
        return probaDBRepository.findAll();
    }
    @Override
    public synchronized Collection<ProbaDTO>getToateProbeleDTO() {
        List<Proba> probe= (List<Proba>) probaDBRepository.findAll();
        List<ProbaDTO>probaDTOS=new ArrayList<>();
        probe.forEach(proba -> {
            ProbaDTO probaDTO=new ProbaDTO(proba.getDenumire(),proba.getVarstaMin(),proba.getVarstaMax(),getNrInscrisiProba(proba));
            probaDTO.setId(proba.getId());
            probaDTOS.add(probaDTO);
        });
        return probaDTOS;

    }

    @Override
    public synchronized Iterable<Participant>getTotiParticipantii() throws SQLException {
        return participantiDBRepository.findAll();
    }
    @Override
    public synchronized Collection<? extends Participant> getParticipantiProbaVarsta(Proba proba)throws  ConcursException
    {

        Iterable<Participant>participantList=participantiDBRepository.getParticipantiProbaVarsta(proba);
        return (Collection<? extends Participant>) participantList;
    }
    @Override
    public synchronized Participant findOneByNumePrenume(String numeDat, String prenumeDat){
        return participantiDBRepository.findOneByNumePrenume(numeDat, prenumeDat);
    }
    @Override
    public synchronized Proba findOneByDenumireVarsta(String denumire, int varstaMin, int varstaMax){
        return probaDBRepository.findOneByDenumireVarsta(denumire, varstaMin, varstaMax);
    }
    private final int defaultThreadsNo=5;


    private void notifyInscriereUpdated(Inscriere inscriere) throws ConcursException {
        ExecutorService executor= Executors.newFixedThreadPool(defaultThreadsNo);
        for(var o: angajatiLogati.entrySet()) {
            executor.execute(() -> {
                try {
                    o.getValue().inscriereUpdated(inscriere);
                } catch (ConcursException | RemoteException e) {
                    System.err.println("Error notifying inregistrari " + e);
                }
            });
        }
        executor.shutdown();
    }
}
