using System;
using System.Data;
using System.Data.SQLite;
using Mono.Data.Sqlite;
namespace ConnectionUtils
{
    public class SqliteConnectionFactory : ConnectionFactory
    {
        public override IDbConnection createConnection()
        {
            //Mono Sqlite Connection
           
          //  String connectionString = "URI=file:C:\\Users\\User\\Desktop\\bazededateMPP\\Concurs.db,Version=3";
           // return new SqliteConnection(connectionString);
           
            // Windows Sqlite Connection, fisierul .db ar trebuie sa fie in directorul debug/bin
            String connectionString = "Data Source=Concurs.db;Version=3";
            return new SQLiteConnection(connectionString);
        }
    }
}