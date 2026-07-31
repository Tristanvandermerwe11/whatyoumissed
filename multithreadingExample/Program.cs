namespace multithreadingExample
{
    internal class Program
    {
        static void PrintNumbers()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Working thread: {i}");
                Thread.Sleep(500);// number represends miliseconds. 
            }

        }

        static BankAccount account = new BankAccount();


        static void UseATM(string atmName)
        {
            account.WithDraw(500, atmName); 
        }
        static void Main(string[] args)
        {
            //Single-Threaded
            // o Class are dependant on a previous task.
            // o Task 1 -> task 2 - > Task 3

            //Multi - Threading
            // o Tasks are not dependent on other tasks. 


            Thread t1 = new Thread(PrintNumbers);

            t1.Start(); // starts the worker thread 

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Main Thread: {i}");
                Thread.Sleep(500); 
            }

            Thread atm1 = new Thread(() => UseATM("ATM 1")),
              atm2= new Thread(() => UseATM("ATM 2")),
             atm3 = new Thread(() => UseATM("ATM 3"));


            atm1.Start();
            atm2.Start();
            atm3.Start();


            // required so the threads wait for each other to be completed first 

            atm1.Join();
            atm2.Join();   
            atm3.Join();

            Console.WriteLine("All ATM transactions completed");



        }
    }
}
