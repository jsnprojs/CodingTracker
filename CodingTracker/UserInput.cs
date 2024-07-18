using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker;
internal class UserInput
{
    internal static string GetDateInput(string startOrEnd)
    {
        Console.WriteLine($"\n\nPlease insert the date for {startOrEnd}: (Format: hours(24 hours system)-day-month-year). Type 0 to return to main manu.\n\n");

        string dateInput = Console.ReadLine();

        if (dateInput == "0") Menu.GetUserInput();

        while (!DateTime.TryParseExact(dateInput, "HH-dd-MM-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
        {
            Console.WriteLine("\n\nInvalid date. (Format: hours-day-month-year). Type 0 to return to main manu or try again:\n\n");
            dateInput = Console.ReadLine();
        }

        return dateInput;
    }
}
