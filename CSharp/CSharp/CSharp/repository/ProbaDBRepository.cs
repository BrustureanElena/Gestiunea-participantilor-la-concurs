using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using CSharp.domain;
using log4net;
namespace CSharp.repository
{
    public class ProbaDBRepository:IProbaRepository
    {
        private static readonly ILog log = LogManager.GetLogger("ProbaDBRepository");
        public ProbaDBRepository()
        {
            log.Info("Creating ProbaDBRepository");
        }
        public void Add(Proba elem)
        {
            log.InfoFormat("Add proba {0}",elem);
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Probe(denumire,varstaMin,varstaMax) values (@denumire,@varstaMin,@varstaMax)";
                comm.Parameters.Add(new SQLiteParameter("@denumire", elem.Denumire));
                comm.Parameters.Add(new SQLiteParameter("@varstaMin", elem.VarstaMin));
                comm.Parameters.Add(new SQLiteParameter("@varstaMax", elem.VarstaMax));
                var result = comm.ExecuteNonQuery();
                if(result==0)
                    log.Error("Error Add proba");
                else
                {
                    log.Info("Successful adding");
                }
            }
        }

        public IEnumerable<Proba> FindAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Proba> probe = new List<Proba>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Probe";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idP = dataR.GetInt32(0);
                        String denumire = dataR.GetString(1);
                        int varstaMin = dataR.GetInt32(2);
                        int varstaMax = dataR.GetInt32(3);

                        Proba proba = new Proba(denumire, varstaMin, varstaMax);
                     
                        proba.Id = idP;
                        probe.Add(proba);
                    
                    }
                }
            }

            return probe;
        }

        public List<Proba> findAllByDenumire(string denumire)
        {
            IDbConnection con = DBUtils.getConnection();
            log.InfoFormat("Entering findOne with value {0}", denumire);
            List<Proba> probe = new List<Proba>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Probe where denumire=@denumire";
                IDbDataParameter paramDenumire = comm.CreateParameter();
                paramDenumire.ParameterName = "@denumire";
                paramDenumire.Value = denumire;
                comm.Parameters.Add(paramDenumire);

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idP = dataR.GetInt32(0);
                        String denumire2 = dataR.GetString(1);
                        int varstaMin = dataR.GetInt32(2);
                        int varstaMax = dataR.GetInt32(3);

                        Proba proba = new Proba(denumire2, varstaMin, varstaMax);
                     
                        proba.Id = idP;
                        probe.Add(proba);
                    
                    }
                }
            }

            return probe;
            
        }

     

        public Proba FindOne(long id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Probe where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idP = dataR.GetInt32(0);
                        String denumire = dataR.GetString(1);
                     
                        int varstaMin = dataR.GetInt32(2);
                        int varstaMax = dataR.GetInt32(3);

                        Proba proba = new Proba(denumire, varstaMin, varstaMax);
                       
                        proba.Id = idP;
                        
                        log.InfoFormat("Exiting findOne with value {0}", proba);
                        return proba;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        //de revazut
        public Proba findOneByDenumireVarsta(string denumire, int varstaMin, int varstaMax)
        {
            log.InfoFormat("Entering findOne with value {0}{1}{2}", denumire,varstaMin,varstaMax);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Probe where denumire=@denumire and varstaMin=@varstaMin";
                IDbDataParameter paramId = comm.CreateParameter();
                IDbDataParameter paramId2 = comm.CreateParameter();
                IDbDataParameter paramId3 = comm.CreateParameter();
                paramId.ParameterName = "@denumire";
                paramId.Value = denumire;
                paramId2.ParameterName = "@varstaMin";
                paramId2.Value = varstaMin;
                paramId3.ParameterName = "@varstaMax";
                paramId3.Value = varstaMax;
                comm.Parameters.Add(paramId);
                comm.Parameters.Add(paramId2);
                comm.Parameters.Add(paramId3);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idP = dataR.GetInt32(0);
                        String denumire1 = dataR.GetString(1);
                     
                        int varstaMin1 = dataR.GetInt32(2);
                        int varstaMax1 = dataR.GetInt32(3);

                        Proba proba = new Proba(denumire1, varstaMin1, varstaMax1);
                       
                        proba.Id = idP;
                        
                        log.InfoFormat("Exiting findOne with value {0}", proba);
                        return proba;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}{1}{2}", null);
            return null;
        }
    }
}