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
using System.Web.UI.WebControls.WebParts;
using CSharp.service;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
           
       
           XmlConfigurator.Configure(new System.IO.FileInfo(args[0]));


            IParticipantRepository participantDbRepository = new ParticipantDBRepository();
            IProbaRepository probaDbRepository = new ProbaDBRepository();
            IInscriereRepository inscriereDbRepository =
                new InscriereDBRepository(participantDbRepository, probaDbRepository);
         
           
          
           /* Console.WriteLine("Toti participantii din db: ");
            foreach (Participant t in participantDbRepository.FindAll())
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("Participantul cu id 9 este: ");
          
                Console.WriteLine(participantDbRepository.FindOne(9L));
         
            */
            
            Console.WriteLine("Toate probele:  ");
            foreach (Proba p in probaDbRepository.FindAll())
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Proba cu id 2 este: ");
          
            Console.WriteLine(probaDbRepository.FindOne(2L));

            Console.WriteLine("Toate inscrierile sunt:  ");
            foreach (Inscriere p in inscriereDbRepository.FindAll())
            {
                Console.WriteLine(p);
            }
           Console.WriteLine("Toate probele de desen: ");
            foreach (Proba p in probaDbRepository.findAllByDenumire("desen"))
            {
                Console.WriteLine(p);
            }
          

            Console.WriteLine("Participantii de la  proba 3");
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

            Participant participant3 = new Participant("Bursuc", "Vasile", 12);
            //participantDbRepository.Add(participant3);
            foreach (Participant t in participantDbRepository.FindAll())
            {
                Console.WriteLine(t);
            }

            Inscriere inscriere2 = new Inscriere(participantDbRepository.FindOne(8), probaDbRepository.FindOne(4));
            //inscriereDbRepository.Add(inscriere2);
            
            foreach (Inscriere t in inscriereDbRepository.FindAll())
            {
                Console.WriteLine(t);
            }

            AngajatOficiuDBRepository angajatOficiuDbRepository = new AngajatOficiuDBRepository();
            Service service = new Service(participantDbRepository, probaDbRepository, inscriereDbRepository,angajatOficiuDbRepository
                );
            Console.WriteLine("OPRIS DAN ESTEEEE");
            Console.WriteLine(service.findOneByNumePrenume("Opris","Dan"));
            Console.WriteLine("Proba 6 8 este");
            Console.WriteLine(service.findOneByDenumireVarsta("desen",6,8));
            
             
            foreach (Participant t in service.getTotiParticipantii())
            {
                Console.WriteLine(t);
            }

            foreach (Proba t in service.getToateProbele())
            {
                Console.WriteLine(t);
            }

            Proba _proba = probaDbRepository.FindOne(1L);
                
                Console.WriteLine("Participantii de la proba 1: ");
                foreach (Participant a in service.getParticipantiProbaVarsta(_proba))
                {
                    Console.WriteLine(a);
                }
               
                Console.WriteLine(service.getNrInscrisiProba(_proba));

                Participant participant5 = participantDbRepository.FindOne(8l);
                Proba proba5 = probaDbRepository.FindOne(2l);
                Inscriere inscriere = new Inscriere(participant5, proba5);
               // service.addInscriere(participant5.Nume,participant5.Prenume,participant5.Varsta,proba5);
               Participant participantNexistent = new Participant("Popa", "Traian", 15);
               Inscriere inscriere6 = new Inscriere(participantNexistent, proba5);
             //  service.addInscriere(participantNexistent.Nume,participantNexistent.Prenume,participantNexistent.Varsta,proba5);
               
               Console.WriteLine("DTO-URILE");
               foreach (ProbaDTO t in service.getToateProbeleDTO())
               {
                   Console.WriteLine(t);
               }
               
               Console.WriteLine("add with return");
               Participant participantAdd = new Participant("pop", "gloa", 11);
               Console.WriteLine(participantDbRepository.AddWithReturn(participantAdd));
               Console.WriteLine("aicciii");
        }
    }
}
