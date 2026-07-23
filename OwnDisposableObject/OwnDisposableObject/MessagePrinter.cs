using System;
using System.Collections.Generic;
using System.Text;

namespace OwnDisposableObject
{
    internal class MessagePrinter : IDisposable
    {
        public delegate void PrintMessage(string message);

        private PrintMessage print;

        public MessagePrinter(PrintMessage printMethode)
        {
            print = printMethode;

            Console.WriteLine("message printer created");
        }

        public void Print(string message)
        {
            print(message);
        }

        public void Dispose()
        {
            Console.WriteLine("Message disposed");
        }
    }
}
