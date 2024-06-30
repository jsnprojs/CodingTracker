namespace CodingTracker;


internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Menu menu = new();
        menu.GetUserInput();
    }
}
