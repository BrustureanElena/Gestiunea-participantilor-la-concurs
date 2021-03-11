using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using CSharp.domain;

using log4net;
namespace CSharp.repository
{
    public class ParticipantDBRepository:IParticipantRepository
    {
        
        private static readonly ILog log = LogManager.GetLogger("ParticipantDBRepository");
    
        
        public void Add(Participant entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Participanti  values (@id, @nume, @prenume, @varsta)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.Nume;
                comm.Parameters.Add(paramNume);
                
                var paramPrenume = comm.CreateParameter();
                paramPrenume.ParameterName = "@prenume";
                paramPrenume.Value = entity.Prenume;
                comm.Parameters.Add(paramPrenume);

                var paramVarsta = comm.CreateParameter();
                paramVarsta.ParameterName = "@varsta";
                paramVarsta.Value = entity.Varsta;
                comm.Parameters.Add(paramVarsta);

               

                var result = comm.ExecuteNonQuery();
              
                //   throw new RepositoryException("No task added !");
            }
			
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

        public Participant FindOne(long id)
        {
            throw new System.NotImplementedException();
        }

        public int GetNrParticipantiProbaVarsta(Proba proba)
        {
            throw new System.NotImplementedException();
        }

        public List<Participant> getParticipantiProbaVarsta(Proba proba)
        {
            throw new System.NotImplementedException();
        }

        public Participant FindOneByNumePrenume(string nume, string prenume)
        {
            throw new System.NotImplementedException();
        }
    }
}