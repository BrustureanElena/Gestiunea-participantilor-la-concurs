using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp.repository;
using CSharp.service;
using log4net.Config;
using System.Data.SQLite;
using CSharp.domain;

namespace CsharpInterfata
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            XmlConfigurator.Configure(new System.IO.FileInfo("App.config"));


            IParticipantRepository participantDbRepository = new ParticipantDBRepository();
            IProbaRepository probaDbRepository = new ProbaDBRepository();
            IInscriereRepository inscriereDbRepository =
                new InscriereDBRepository(participantDbRepository, probaDbRepository);
            IAngajatOficiuRepository angajatOficiuDBRepository = new AngajatOficiuDBRepository();
            Service service = new Service(participantDbRepository, probaDbRepository, inscriereDbRepository, angajatOficiuDBRepository);

            Console.WriteLine("Username beir:");
            Console.WriteLine(probaDbRepository.FindOne(1l));
            Console.WriteLine(angajatOficiuDBRepository.findOneByUsername("beir"));
            //Console.WriteLine(angajatOficiuDBRepository.FindOne(2l));

            Console.WriteLine("DTO-URILE");
            foreach (ProbaDTO t in service.getToateProbeleDTO())
            {
                Console.WriteLine(t);
            }
             Application.Run(new Form1(service));

        }
    }
}
