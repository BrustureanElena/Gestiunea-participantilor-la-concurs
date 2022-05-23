using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

using log4net;
using model;

namespace persistence
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
   
        }
        
        public Participant AddWithReturn(Participant elem)
        {
            log.InfoFormat("Add participant with return {0}",elem);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Participanti(nume,prenume,varsta) values (@nume, @prenume, @varsta)";
                comm.Parameters.Add(new SQLiteParameter("@nume",elem.Nume));
                comm.Parameters.Add(new SQLiteParameter("@prenume", elem.Prenume));
                comm.Parameters.Add(new SQLiteParameter("varsta", elem.Varsta));
                
                try
                {
                    var result = comm.ExecuteNonQuery();
                    if (result == 0) 
                        log.Info("Succesful adding!");
                    
                    using (var comm2 = con.CreateCommand())
                    {
                        comm2.CommandText = "select * from Participanti where id = last_insert_rowid()";
                        
                        using (var dataR = comm2.ExecuteReader())
                        {
                            if (dataR.Read())
                            {
                                long idP = dataR.GetInt64(0);
                                String numeP = dataR.GetString(1);
                                String prenumeP = dataR.GetString(2);
                                int varstaP = dataR.GetInt32(3);

                                Participant participant = new Participant(numeP, prenumeP, varstaP);
                                participant.Id = idP; //set ID
                                
                                log.InfoFormat("Exiting addWithReturn with value {0}", participant);
                                return participant;
                            }
                        }
                    }
                    
                }
                catch(Exception e)
                {
                    log.Error("Error AddWithReturn Participant: " + e.Message);
                }
            }

            return null;
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
        
       

        public Participant findOneByNumePrenume2(string nume, string prenume)
        {
            log.InfoFormat("Entering findOne with value {0}{1}", nume,prenume);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Participanti where nume=@nume and prenume=@prenume";
                IDbDataParameter paramId = comm.CreateParameter();
                IDbDataParameter paramId2 = comm.CreateParameter();
             
                paramId.ParameterName = "@nume";
                paramId.Value = nume;
                paramId2.ParameterName = "@prenume";
                paramId2.Value = prenume;
              
                comm.Parameters.Add(paramId);
                comm.Parameters.Add(paramId2);
            

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idP = dataR.GetInt32(0);
                        String nume1 = dataR.GetString(1);
                        String prenume1 = dataR.GetString(2);
                     
                        int varsta1 = dataR.GetInt32(3);

                        Participant participant = new Participant(nume1, prenume1, varsta1);

                        participant.Id = idP;
                     
                        
                        log.InfoFormat("Exiting findOne with value {0}",  participant);
                        return  participant;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}{1}", null);
            return null;
        }
    }
}