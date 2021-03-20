package concurs;

import concurs.domain.Inscriere;
import concurs.domain.Participant;
import concurs.domain.Proba;
import concurs.repository.AngajatiOficiuDBRepository;
import concurs.repository.InscriereDBRepository;
import concurs.repository.ParticipantiDBRepository;
import concurs.repository.ProbaDBRepository;
import concurs.service.Service;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.sql.SQLOutput;
import java.util.Properties;

public class Main {
    public static void main(String[] args) {
        Properties props=new Properties();
        try {
            System.out.println((new File(".")).getAbsolutePath());
            props.load(new FileReader("bd.properties"));
        } catch (IOException e) {
            System.out.println("Cannot find bd.properties "+e);
        }


        ParticipantiDBRepository participantiDBRepository=new ParticipantiDBRepository(props);
        //test pt addParticipant
       // participantiDBRepository.add(new Participant("Balaie","Paul",2));
        //test pt findAllParticipant
        System.out.println("Toti participantii din db");
        for(Participant p: participantiDBRepository.findAll())
            System.out.println(p);



        System.out.println("asta e participantu cu id 8:" + participantiDBRepository.findOne(8L));

        ProbaDBRepository probaDBRepository=new ProbaDBRepository(props);
     //   probaDBRepository.add(new Proba("cautarea unei comori",4,5));
        System.out.println("Toate probele sunt: ");
        for(Proba p:probaDBRepository.findAll())
            System.out.println(p);
       // System.out.println("asta e proba cu idul 1:" + probaDBRepository.findOne(1L));
        //System.out.println("asta e proba cu desen:" + probaDBRepository.findOneByDenumire("desen"));
        //System.out.println("toate comorile");
       // for(Proba p1:probaDBRepository.findAllByDenumire("cautarea unei comori"))
        //    System.out.println(p1);

        InscriereDBRepository inscriereDBRepository=new InscriereDBRepository(props,participantiDBRepository
        ,probaDBRepository);
    //   inscriereDBRepository.add(new Inscriere(participantiDBRepository.findOne(3L), probaDBRepository.findOne(3L)));

        //test pt findAllInscrieri
        System.out.println("Inscrierile toate: ");
        for(Inscriere i:inscriereDBRepository.findAll())
            System.out.println(i);


        System.out.println("Toti participanti  la proba si grupa de varsta: ");
        Participant participant3=participantiDBRepository.findOne(8l);
        Participant participant4=participantiDBRepository.findOne(10l);
        Proba proba3= probaDBRepository.findOne(7L);
        Inscriere inscriere3=new Inscriere(participant3,proba3);
        Inscriere inscriere4=new Inscriere(participant4,proba3);

        //inscriereDBRepository.add(inscriere3);
   //     inscriereDBRepository.add(inscriere4);
        for(Participant p:participantiDBRepository.getParticipantiProbaVarsta(proba3))
            System.out.println(p);
        System.out.println("Numarul de participanti de la proba 3 este: "+participantiDBRepository.getNrParticipantiProbaVarsta(proba3));

        AngajatiOficiuDBRepository angajatiOficiuDBRepository=new AngajatiOficiuDBRepository(props);
        System.out.println(angajatiOficiuDBRepository.findOneByUsername("beir"));


        System.out.println("Serviceeee");


        Service service=new Service(participantiDBRepository,probaDBRepository,inscriereDBRepository,angajatiOficiuDBRepository);
        System.out.println();
        //service.addInscriere(participant3,proba3);


        for(Proba p:service.getToateProbele())
            System.out.println(p);
        for(Participant p:service.getTotiParticipantii())
            System.out.println(p);
        Proba proba7= probaDBRepository.findOne(6L);
     //   for(Participant p:service.getParticipantiProbaVarsta(proba7))
           // System.out.println(p);
        System.out.println("Poezia 14 16");
        System.out.println(service.findOneByDenumireVarsta("poezie",14,16));

        System.out.println("Opris dan este");
        System.out.println(service.findOneByNumePrenume("Opris","Dan"));

    }
}
