using System;
using System.Collections.Generic;
using System.Linq;

namespace L05.Sudents2._0
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
                string firstName = cmd[0];
                string lastName = cmd[1];
                int age = int.Parse(cmd[2]);
                string homeTown = cmd[3];

                Student student = studentList.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
                if (student == null)
                {
                    studentList.Add(new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        HomeTown = homeTown
                    });
                }
                else
                {
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.HomeTown = homeTown;
                }

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
