using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Web.UI;
using CSharp.domain;

using log4net;

namespace CSharp.repository
{
    public class ParticipantDBRepository : IParticipantRepository
    {
        private static readonly ILog log = LogManager.GetLogger("ParticipantDBRepository");
        public ParticipantDBRepository()
        {
            log.Info("Creating ParticipantDBRepository");
        }
        public void Add(Participant elem)
        { log.InfoFormat("Add participant{0}",elem);
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Participanti(nume,prenume,varsta) values (@nume,@prenume,@varsta)";
                comm.Parameters.Add(new SQLiteParameter("@nume", elem.Nume));
                comm.Parameters.Add(new SQLiteParameter("@prenume", elem.Prenume));
                comm.Parameters.Add(new SQLiteParameter("@varsta", elem.Varsta));
                var result = comm.ExecuteNonQuery();
                if(result==0)
                    log.Error("Error Add participant");
                else
                {
                    log.Info("Successful adding");
                }
            }
           // throw new NotImplementedException();
        }

        public IEnumerable<Participant> FindAll()
        {

            IDbConnection con = DBUtils.getConnection();
            IList<Participant> participants = new List<Participant>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Participanti";
                
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    { 
                        int id = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String prenume = dataR.GetString(2);
                        int varsta = dataR.GetInt32(3);
                       

                        Participant participant = new Participant(nume,prenume,varsta);
                        
                        participant.Id = id;
                       participants.Add(participant);
                    }
                }
            }

            return participants;
        }

        public Participant FindOne(long id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Participanti where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idP = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String prenume = dataR.GetString(2);
                        int varsta = dataR.GetInt32(3);
                       

                        Participant participant = new Participant(nume,prenume,varsta);
                        participant.Id = idP;
                        
                        log.InfoFormat("Exiting findOne with value {0}", participant);
                        return participant;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        
        }

        public int GetNrParticipantiProbaVarsta(Proba proba)
        {

            return GetParticipantiProbaVarsta(proba).Count;
            // throw new NotImplementedException();

        }

        public List<Participant> GetParticipantiProbaVarsta(Proba proba)
        {
            long idProbaData = proba.Id;
            IDbConnection con = DBUtils.getConnection();
            log.InfoFormat("Entering findOne with proba {0}", idProbaData);
            List<Participant> participants = new List<Participant>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Participanti p inner join Inscrieri I on p.id = I.idParticipant where idProba=@idProbaData;";
                IDbDataParameter paramIdProbaData = comm.CreateParameter();
                paramIdProbaData.ParameterName = "@idProbaData";
                paramIdProbaData.Value = idProbaData;
                comm.Parameters.Add(paramIdProbaData);

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idP = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String prenume = dataR.GetString(2);
                       
                        int varsta = dataR.GetInt32(3);
                        Participant participant = new Participant(nume, prenume, varsta);
                        participant.Id = idP;
                     
                        
                        participants.Add(participant);
                    
                    }
                }
            }

            return participants;
        }

        public Participant FindOneByNumePrenume(string nume, string prenume)
        {
            
          /*  log.InfoFormat("Entering findOne with value {0}", nume);
            log.InfoFormat("Entering findOne with value {1}", prenume);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Participanti where nume=@nume AND prenume=@prenume";
                IDbDataParameter paramNume = comm.CreateParameter();
                IDbDataParameter paramPrenume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = nume;
                comm.Parameters.Add(paramNume);
                paramPrenume.ParameterName = "@prenume";
                paramPrenume.Value = prenume;
                comm.Parameters.Add(paramPrenume);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idP = dataR.GetInt32(0);
                        String nume2 = dataR.GetString(1);
                        String prenum2 = dataR.GetString(2);
                        int varsta = dataR.GetInt32(3);

                        Participant participant = new Participant(nume2, prenum2, varsta);
                        
                       
               
                        participant.Id = idP;
                        log.InfoFormat("Exiting findOne with value {0},{1}", participant);
                        return participant;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0},{1}", null);
            return null;*/
            throw new NotImplementedException();
        }
    }
}