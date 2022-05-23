using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using CSharp.domain;
using log4net;
namespace CSharp.repository
{
    public class InscriereDBRepository:IInscriereRepository
    {
        private IParticipantRepository _participantDbRepository;
        private IProbaRepository _probaDbRepository;

        public InscriereDBRepository(IParticipantRepository participantDbRepository, IProbaRepository probaDbRepository)
        {
            _participantDbRepository = participantDbRepository;
            _probaDbRepository = probaDbRepository;
        }

        private static readonly ILog log = LogManager.GetLogger("InscriereDBRepository");
        public InscriereDBRepository()
        {
            log.Info("Creating InscriereDBRepository");
        }
        public void Add(Inscriere elem)
        {
            log.InfoFormat("Add inscriere {0}",elem);
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Inscrieri(idParticipant,idProba) values (@idParticipant,@idProba)";
                comm.Parameters.Add(new SQLiteParameter("@idParticipant", elem.Participant.Id));
                comm.Parameters.Add(new SQLiteParameter("@idProba", elem.Proba.Id));
               
                var result = comm.ExecuteNonQuery();
                if(result==0)
                    log.Error("Error Add inscriere");
                else
                {
                    log.Info("Successful adding");
                }
            }
            //throw new System.NotImplementedException();
        }



     
        public IEnumerable<Inscriere> FindAll()
        {
        
            
            IDbConnection con = DBUtils.getConnection();
            IList<Inscriere>inscrieri= new List<Inscriere>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Inscrieri";
                
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    { 
                        int id = dataR.GetInt32(0);
                        int idParticipant = dataR.GetInt32(1);
                        int idProba = dataR.GetInt32(2);
                       
                       

                        Inscriere inscriere = new Inscriere(_participantDbRepository.FindOne(idParticipant)
                        ,_probaDbRepository.FindOne(idProba));
                        inscriere.Id = id;
                        inscrieri.Add(inscriere);
                     
                    }
                }
            }

            return inscrieri;


            
        }
    }
}