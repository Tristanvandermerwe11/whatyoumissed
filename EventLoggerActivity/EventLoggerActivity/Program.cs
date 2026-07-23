using System.Runtime.CompilerServices;

namespace EventLoggerActivity
{
    internal class Program
    {
        static void Main(string[] args)
        {

            EventLogger logger = new EventLogger(Log);

            try
            {
                string log = $"Application started up - {DateTime.Now}";
                logger.Log(log);

                string choice = string.Empty;
                string name = string.Empty;

                while (choice != "3")
                {
                    Console.WriteLine("Please select one of the following options from the menu");
                    Console.WriteLine("""
                                            -- MENU --

                                        1. Enter name
                                        2. Greet
                                        3. Exit

                                        """);

                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":

                            name = string.Empty;
                            while (string.IsNullOrEmpty(name))
                            {
                                Console.Write("\nPlease provide your name: ");
                                name = Console.ReadLine();
                            }

                            log = $"Name saved - {DateTime.Now}";
                            logger.Log(log);

                            break;
                        case "2":
                            if (string.IsNullOrEmpty(name))
                            {
                                Console.WriteLine("\nWelcome, User! Try providing your name so I can greet you more personally :D\n");
                            }
                            else
                            {
                                Console.WriteLine($"\nWelcome, {name} :D\n");
                            }

                            log = $"Greeting - {DateTime.Now}";
                            logger.Log(log);

                            break;
                        default:
                            Console.WriteLine("Only choose an option from the menu using the number values provided.\n");
                            break;
                    }
                }

                log = $"Application Stopped - {DateTime.Now}";
                logger.Log(log);
            }
            finally
            {
                logger.Dispose();
            }
        }

        static void Log(string eventDetails)
        {
            string filePath = "eventLogs.txt";

            StreamWriter writer = new StreamWriter(filePath, true);

            try
            {
                writer.WriteLine(eventDetails);
                Console.WriteLine("The logs have been updated!\n");
            }
            finally
            {
                writer.Dispose();
            }
        }
    }
}

//Create an event logger application that makes use of delegates and disposable objects
//The application should be able to log events to a .txt file or display them in the console
//Events that are logged should include a timestamp and the event message
//The following events should be logged:
//   - Application Start
//   - A custom event that the user wants to log
//   - Application Stop