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
        string startDate = UserInput.GetDateInput("StartDate");
        string endDate = UserInput.GetDateInput("EndDate");
        string? sql;

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

        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            sql = $"INSERT INTO CodingSessions(StartTime, EndTime, Duration) VALUES('{startDate}', '{endDate}', {duration})";
            connection.Execute(sql);

            connection.Close();
        }
        
    }

}
