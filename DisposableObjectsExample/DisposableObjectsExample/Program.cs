namespace DisposableObjectsExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "message.txt";

            StreamWriter writer = new StreamWriter(filePath);

            try
            {
                writer.WriteLine("hello world");
                writer.WriteLine("this file was created using a disposable object");

                writer.WriteLine($"Date: {DateTime.Now}");


            }
            finally
            {
                writer.Dispose();
            }






            // from here
            using (StreamWriter writer1 = new StreamWriter(filePath))
            {
                writer1.WriteLine("hello world");
                writer1.WriteLine("this file was created using a disposable object");

                writer1.WriteLine($"Date: {DateTime.Now}");
            }
            // to here
            //dispose() is already called for this block






                Console.WriteLine("File created successfully");
        }
    }
}
