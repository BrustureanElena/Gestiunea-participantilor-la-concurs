using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using System.Resources;

using Mono.Data.Sqlite;
namespace persistence
{
    public class SqliteConnectionFactory : ConnectionFactory
    {
        public override IDbConnection createConnection()
        {
            //Mono Sqlite Connection

            //  String connectionString = "URI=file:C:\\Users\\User\\Desktop\\MPPLab\laborator\mpp-proiect-repository-BrustureanElena\CSharp\CSharp\CSharp\bin\Debug\Concurs.db,Version=3";
            // return new SqliteConnection(connectionString);

            // Windows Sqlite Connection, fisierul .db ar trebuie sa fie in directorul debug/bin

            //  String connectionString = "Data Source=C:\\Users\\User\\Desktop\\MPPLab\\laborator\\mpp-proiect-repository-BrustureanElena\\CSharp\\CSharp\\CSharp\\bin\\Debug\\Concurs.db;Version=3";
            //  return new SQLiteConnection(connectionString);

            //  ResourceManager resource = new ResourceManager("ConnectionUtils.db", Assembly.GetExecutingAssembly());
            //  var DataSource = resource.GetString("Data Source");
            //  var Version = resource.GetString("Version");
            // return new SQLiteConnection(DataSource + Version);
            
            
            String connectionString = ConfigurationManager.ConnectionStrings["Concurs.db"].ConnectionString;
            return new SQLiteConnection(connectionString);
              //Console.WriteLine("creating ... sqlite connection");
			//String connectionString = "URI=file:ChatMPP2017.db,Version=3";
			return new SqliteConnection(connectionString);
        }
    }
}