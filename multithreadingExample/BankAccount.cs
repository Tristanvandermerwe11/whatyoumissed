using System;
using System.Collections.Generic;
using System.Text;

namespace multithreadingExample
{
    class BankAccount
    {
        private decimal balance = 1000;

        private readonly object balanceLock = new object ();


        public void WithDraw(decimal amount, string atmName)
        {
            //aDDED TO ENSURE WE DONT GET A NEGATIVE BANK BALANCE
            lock (balanceLock)
            {
                Console.WriteLine($"{atmName} is attempting to withdraw R{amount}");

                if (balance >= amount)
                {
                    Console.WriteLine($"{atmName} approved");

                    Thread.Sleep(1000);

                    balance -= amount;

                    Console.WriteLine($"{atmName} withdrew R{amount}");
                    Console.WriteLine($"Remaining balance: R{balance}\n");


                } else
                {
                    Console.WriteLine($"{atmName} declinded. Insufficeient Funds\n");

                }
            }
        }
    }
}
