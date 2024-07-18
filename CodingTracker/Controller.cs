using CodingTracker.Models;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Configuration;
using System.Data;
using System.Globalization;


namespace CodingTracker;
internal class Controller
{
    static string connectionString = ConfigurationManager.AppSettings.Get("connectionString");
    static string tableString = ConfigurationManager.AppSettings.Get("connectionString");

    static internal void Insert()
    {
        Console.Clear();
        ShowTable();

        string startDate = UserInput.GetDateInput("StartDate");
        string endDate = UserInput.GetDateInput("EndDate");
        

        DateTime start;
        DateTime.TryParseExact(startDate, "HH-dd-MM-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out start);
        DateTime end;
        DateTime.TryParseExact(endDate, "HH-dd-MM-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out end);

        if(end < start)
        {
            Console.WriteLine("End date must be later than the startDate, please enter again.");
            endDate = UserInput.GetDateInput("EndDate");
        }
        double duration = (end - start).TotalHours;

        string? sql;
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            sql = $"INSERT INTO CodingSessions(StartTime, EndTime, Duration) VALUES('{startDate}', '{endDate}', {duration})";
            connection.Execute(sql);

            connection.Close();
        }
    }

    static internal void ShowTable()
    {
        Console.Clear();

        string? sql;

        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            sql = $"SELECT * FROM CodingSessions";
            var table = connection.Query<CodingSessions>(sql);

            foreach (var row in table) {
                Console.WriteLine($"ID:{row.ID}");
                Console.WriteLine($"StartDate:{row.StartTime}");
                Console.WriteLine($"EndDate:{row.EndTime}");
                Console.WriteLine($"Duration:{row.Duration}");
                Console.WriteLine();
            }
            
            connection.Close();
        }
        Console.WriteLine("press anything to go back to main menu");
        Console.ReadLine();
    }

    static internal void Delete()
    {
        Console.Clear();
        ShowTable();

        string? sql;
        int id = UserInput.GetNumberInput("Enter the id to delete that row");

        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            sql = $"DELETE FROM CodingSessions WHERE ID='{id}'";

            if (0 == connection.Execute(sql))
            {
                Console.WriteLine("the id does not exist in this table, please try again");
                Delete();
            }

            connection.Close();
        }
    }
}
