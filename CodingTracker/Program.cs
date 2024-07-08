using Microsoft.Data.Sqlite;
using System.Configuration;

namespace CodingTracker;

internal class Program
{
    static void Main(string[] args)
    {
        string connectionString = ConfigurationManager.AppSettings.Get("connectionString");

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            



            connection.Close();

        }
    }
}
