using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.domain;
using CSharp.repository;
using log4net.Config;
using System.IO;
using System.Configuration;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //Console.WriteLine ("Hello World!");
           XmlConfigurator.Configure(new System.IO.FileInfo(args[0]));


            ParticipantDBRepository participantDbRepository = new ParticipantDBRepository();
            ProbaDBRepository probaDbRepository = new ProbaDBRepository();
            InscriereDBRepository inscriereDbRepository =
                new InscriereDBRepository(participantDbRepository, probaDbRepository);
         
           
          
            Console.WriteLine("Participantii: ");
            foreach (Participant t in participantDbRepository.FindAll())
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("Participantul cu id 9 este: ");
          
                Console.WriteLine(participantDbRepository.FindOne(9L));
         
            
            
            Console.WriteLine("Probele:  ");
            foreach (Proba p in probaDbRepository.FindAll())
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Proba cu id 2 este: ");
          
            Console.WriteLine(probaDbRepository.FindOne(2L));

            Console.WriteLine("Inscrierile sunt:  ");
            foreach (Inscriere p in inscriereDbRepository.FindAll())
            {
                Console.WriteLine(p);
            }
           Console.WriteLine("Toate probele la desen: ");
            foreach (Proba p in probaDbRepository.findAllByDenumire("desen"))
            {
                Console.WriteLine(p);
            }
            //Console.WriteLine("Participanul Opris Dan este: ");
          //  Console.WriteLine(participantDbRepository.FindOneByNumePrenume("Opris","Dan"));

            Console.WriteLine("Participantii de la o proba");
            Proba proba = probaDbRepository.FindOne(3);
            foreach (Participant p in participantDbRepository.GetParticipantiProbaVarsta(proba))
            {
                Console.WriteLine(p);
            }
            
            Console.WriteLine("Numarul de participanti de la proba:  ");
            Console.WriteLine(participantDbRepository.GetNrParticipantiProbaVarsta(proba));
            
            
            Proba proba3 = new Proba("poezie", 14, 16);
           // probaDbRepository.Add(proba3);
            
            Console.WriteLine("Probele:  ");
            foreach (Proba p in probaDbRepository.FindAll())
            {
                Console.WriteLine(p);
            }

            Participant participant3 = new Participant("Groza", "Ionut", 20);
            //participantDbRepository.Add(participant3);
            foreach (Participant t in participantDbRepository.FindAll())
            {
                Console.WriteLine(t);
            }

            Inscriere inscriere2 = new Inscriere(participantDbRepository.FindOne(8), probaDbRepository.FindOne(5));
           // inscriereDbRepository.Add(inscriere2);
            
            foreach (Inscriere t in inscriereDbRepository.FindAll())
            {
                Console.WriteLine(t);
            }
        }
    }
}
