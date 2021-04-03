
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using model;


namespace persistence
{
    public class AngajatOficiuDBRepository:IAngajatOficiuRepository
    {
        public AngajatOficiuDBRepository()
        {
        }

        public void Add(AngajatOficiu elem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AngajatOficiu> FindAll()
        {
            throw new NotImplementedException();
        }

        private static readonly ILog log = LogManager.GetLogger("AngajatOficiuDBRepository");
        public AngajatOficiu findOneByUsername(string username)
        {
            log.InfoFormat("Entering findOne with value {0}", username);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from AngajatOficiu where username=@username";
                IDbDataParameter paramId = comm.CreateParameter();
             

                paramId.ParameterName = "@username";
                paramId.Value = username;
            

                comm.Parameters.Add(paramId);
          


                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idP = dataR.GetInt32(0);
                        String username1 = dataR.GetString(1);
                        String parola1 = dataR.GetString(2);

                       
                        AngajatOficiu angajatOficiu = new AngajatOficiu(username1, parola1);

                        angajatOficiu.Id = idP;


                        log.InfoFormat("Exiting findOne with value {0}", angajatOficiu);
                        return angajatOficiu;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;

        }
        public AngajatOficiu FindOne(long id)
        {
            log.InfoFormat("Entering findOne with value {0}",id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from AngajatOficiu where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();


                paramId.ParameterName = "@id";
                paramId.Value =id;


                comm.Parameters.Add(paramId);



                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idP = dataR.GetInt32(0);
                        String username1 = dataR.GetString(1);
                        String parola1 = dataR.GetString(2);




                        AngajatOficiu angajatOficiu = new AngajatOficiu(username1, parola1);

                        angajatOficiu.Id = idP;


                        log.InfoFormat("Exiting findOne with value {0}", angajatOficiu);
                        return angajatOficiu;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;

        }
    }
}