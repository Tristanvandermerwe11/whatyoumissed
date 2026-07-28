namespace LearnignOutline3To6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //without custom type
            //string name = "alice";
            //int mark = 36;

            //with custom types
            Student student = new Student("Max", 90);

            //operator Overloading
            student = student + 5;

            Console.WriteLine("Student Info:");
            Console.WriteLine("----------------");
            Console.WriteLine("Name: " + student.Name);
            Console.WriteLine("Marks: " + student.Marks);

            //extension method
            Console.WriteLine("grade: " + student.GetGrade());


            //anonamous type
            var summary = new
            {
                StudentName = student.Name,
                FinalMarks = student.Marks,
                Grade = student.GetGrade()
            };

            Console.WriteLine("Student Info:");
            Console.WriteLine("----------------");
            Console.WriteLine("Name: " + summary.StudentName);
            Console.WriteLine("Marks: " + summary.FinalMarks);
            Console.WriteLine("Marks: " + summary.Grade);




        }
    }
}
