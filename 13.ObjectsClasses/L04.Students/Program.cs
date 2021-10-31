using System;
using System.Collections.Generic;
using System.Linq;

namespace L04.Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();

            string[] cmd = Console.ReadLine().Split();
            while (cmd[0] != "end")
            {
                Student student = new Student();
                student.FirstName = cmd[0];
                student.LastName = cmd[1];
                student.Age = int.Parse(cmd[2]);
                student.HomeTown = cmd[3];
                studentList.Add(student);
                cmd = Console.ReadLine().Split();
            }

            string wantedTown = Console.ReadLine();
            List<Student> wantedTownStudentList =
                studentList.Where(t => t.HomeTown == wantedTown).ToList();
            foreach (Student student in wantedTownStudentList)
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
        }
    }
}
