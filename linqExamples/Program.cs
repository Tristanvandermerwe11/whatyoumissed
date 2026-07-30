namespace linqExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //lambda => 

            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            //using the WHERE clause 
            var evenNumbers = numbers.Where(n => n % 2 == 0); // modulas % divides the number by the variable after (2) and return the remainder 

            foreach (var number in evenNumbers)
            {

                Console.WriteLine(number);
            }
            Console.WriteLine();

            //OrderBy example 
            string[] names = { "John", "Alice", "Bob" }; 

            var sortedNames = names.OrderBy(name => name);

            foreach(var name in sortedNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            //select example 
            List<Student> students = new List<Student>
            {
            new Student {name = "Joe", age = 22},
            new Student {name = "Max", age=21},
            new Student {name = "Jane", age =20},
            new Student {name = "Kyle", age = 29}


            };

            var studentNames = students.Select(s => s.name);

            foreach(var student in students)
            {
                Console.WriteLine($"Student name: {student.name}");
            }
            Console.WriteLine();


            //linQ with query syntax
            var studentsAbove20 = from s in students where s.age >= 21 select s;

            Console.WriteLine("Students's Older than 20");


            foreach(var student in studentsAbove20)
            {
                Console.WriteLine(student.name);
            }
        }
    }
}
