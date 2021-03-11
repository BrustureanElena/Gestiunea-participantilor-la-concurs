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
            Console.WriteLine("da");
            //Console.WriteLine ("Hello World!");
           XmlConfigurator.Configure(new System.IO.FileInfo(args[0]));


            ParticipantDBRepository participantDbRepository = new ParticipantDBRepository();
          

         
            Participant participant = new Participant("Bob", "Dani", 13);
            participantDbRepository.Add(participant);
            Participant participant2 = new Participant("Muresan", "Dani", 13);
            participantDbRepository.Add(participant2);
            Console.WriteLine("Participantii: ");
            foreach (Participant t in participantDbRepository.FindAll())
            {
                Console.WriteLine(t);
            }
            

            /* SortingTask task = repo.findOne(4);
             repo.delete(4);
             task.Description = "Ana are mere";
             repo.save(task);
 
             Console.WriteLine("Taskurile din db dupa stergere/adaugare");
             foreach (SortingTask t in repo.findAll())
             {
                 Console.WriteLine(t);
             }*/
        }
    }
}
