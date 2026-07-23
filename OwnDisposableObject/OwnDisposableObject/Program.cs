namespace OwnDisposableObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (MyContainer container = new MyContainer())
            {
                container.AddData("Hello world");
            }

            Console.WriteLine("container disposed");

            using (MessagePrinter printer = new MessagePrinter(Display))
            {
                printer.Print("Hello world");
                printer.Print("this uses a delegate to print messages");

            }
            Console.WriteLine("Printer progam finished");
        }

        static void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}
