using System;
using System.Collections.Generic;
using System.Linq;

namespace E04.Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int studentQty = int.Parse(Console.ReadLine());

            List<Student> studentList = new List<Student>();
            for (int i = 0; i < studentQty; i++)
            {
                string[] studentInfo = Console.ReadLine().Split();
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                double grade = double.Parse(studentInfo[2]);

                Student student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Grade = grade
                };

                studentList.Add(student);
            }

            foreach (Student student in studentList.OrderByDescending(g => g.Grade))
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
        }
    }
}
