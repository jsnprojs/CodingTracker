using System.Configuration;

namespace CodingTracker;

internal class Program
{
    static void Main(string[] args)
    {
        string connectionString = ConfigurationManager.AppSettings.Get("connectionString");
    }
}
