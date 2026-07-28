using System;
using System.Collections.Generic;
using System.Text;

namespace LearnignOutline3To6
{
    class Student
    {
        //custom types
        public string Name { get; set; }

        public int Marks { get; set; }

        public Student(string name, int marks)
        {
            Name = name;
            Marks = marks;
        }

        //operator overloading

        public static Student operator +(Student s, int bonusMarks)
        {
            return new Student(s.Name, s.Marks + bonusMarks);
        }
    }
    //Extension method
    static class StudentExtensions
    {
        public static string GetGrade(this Student stud)
        {
            if (stud.Marks >= 75)
            {
                return "Distinction";
            }
            else if (stud.Marks >= 50)
            {
                return "Pass";
            }
            else
            {
                return "Fail";
            }
        }
    }
}
