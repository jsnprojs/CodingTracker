using Microsoft.Data.Sqlite;
using System.Configuration;
using Dapper;
using System.Data;
namespace CodingTracker;

internal class Program
{
    static void Main(string[] args)
    {
        string connectionString = ConfigurationManager.AppSettings.Get("connectionString");

        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            
            

            connection.Close();

        }
    }
}
