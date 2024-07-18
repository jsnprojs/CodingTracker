﻿using Microsoft.Data.Sqlite;
using System.Configuration;
using Dapper;
using System.Data;
using CodingTracker.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
namespace CodingTracker;

internal class Program
{
    static void Main(string[] args)
    {
        string connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        string tableString = ConfigurationManager.AppSettings.Get("tableString");
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open(); 

            var commandText =
                @$"CREATE TABLE IF NOT EXISTS {tableString} (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        StartTime TEXT NOT NULL,
                        EndTime TEXT NOT NULL,
                        Duration TEXT NOT NULL
                        )";

            var tableName = connection.Query<CodingSessions>(commandText);

            connection.Close();           
        }
     

        Menu.GetUserInput();
    }
}
