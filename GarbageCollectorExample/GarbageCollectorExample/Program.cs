namespace GarbageCollectorExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "joe";
            Console.WriteLine($"Person object created. Persons name: {person.Name}");

            //Here we remove the only reference to the object
            person = null;
            Console.WriteLine("Reference removed");
            Console.WriteLine("object is now eligible for garbage collection :)");

            //garbage collector
            GC.Collect();

            Console.WriteLine("Garbage collection completed");
        }
    }
}
