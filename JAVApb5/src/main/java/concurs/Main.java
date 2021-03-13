package concurs;

import concurs.domain.Inscriere;
import concurs.domain.Participant;
import concurs.domain.Proba;
import concurs.repository.InscriereDBRepository;
import concurs.repository.ParticipantiDBRepository;
import concurs.repository.ProbaDBRepository;

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
       // participantiDBRepository.add(new Participant("Pop","Danicu",2));

        System.out.println("Toti participantii din db");
        for(Participant p: participantiDBRepository.findAll())
            System.out.println(p);


        System.out.println("asta e:" + participantiDBRepository.findOne(1L));

        ProbaDBRepository probaDBRepository=new ProbaDBRepository(props);
       // probaDBRepository.add(new Proba("cautarea unei comori",9,11));
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
        System.out.println("Inscrierile toate: ");
        for(Inscriere i:inscriereDBRepository.findAll())
            System.out.println(i);


        System.out.println("Toti participanti pusi la proba si grupa de varsta: ");
        Proba proba3= probaDBRepository.findOne(3L);
        for(Participant p:participantiDBRepository.getParticipantiProbaVarsta(proba3))
            System.out.println(p);
        System.out.println("Numarul de participanti este: "+participantiDBRepository.getNrParticipantiProbaVarsta(proba3));
        System.out.println("Participantu Pop Dani  este: "+participantiDBRepository.findOneByNumePrenume("Pop","Dani"));


        System.out.println("Toti participantii din db");
        for(Participant p: participantiDBRepository.findAll())
            System.out.println(p);


    }
}
