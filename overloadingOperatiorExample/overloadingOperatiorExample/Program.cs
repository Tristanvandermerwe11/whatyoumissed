namespace overloadingOperatiorExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(6, 8);
            Vector v2 = new Vector(8, 9);

            // without operator overloading

            Vector resault1 = v1.Add(v2);

            Console.WriteLine($"resault without overload: ({resault1.X},{resault1.Y})");


            // with operator overloading

            Vector resault2 = v1 + v2;

            Console.WriteLine($"resault with overload: ({resault2.X},{resault2.Y})");
        }


        
    }
}
