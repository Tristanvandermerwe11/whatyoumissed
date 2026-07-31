using System.Collections.Concurrent;
using System.Diagnostics;


namespace windowsProcesses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();

                Console.WriteLine("----------------------");
                Console.WriteLine("Window Process Dmeo");
                Console.WriteLine("----------------------");
                Console.WriteLine("1. Open the NotePad");
                Console.WriteLine("2. Open Calculator");
                Console.WriteLine("3. Open MS Paint");
                Console.WriteLine("4. Exit");
                Console.WriteLine("\nChoose an Option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Process.Start("notepad.exe");
                        Console.WriteLine("NotePad has been opened");
                        break;

                    case "2":
                        Process.Start("calc.exe");
                        Console.WriteLine("Calculator has been opened");
                        break;

                    case "3":
                        Process.Start("mspaint.exe");
                        Console.WriteLine("MS Paint has been opened");

                        break;


                    case "4":
                        running = false;
                        continue;


                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
                Console.WriteLine("\nPress any key to return to the menu.....");
                Console.ReadKey();
            }
            Console.WriteLine("Application Closed");
        }
    }
}
