using System;

/// <summary>
/// Very dumb scenario raised by me in the "Iterators & Comparators" lecture:
/// Can we have a dictionary that enumerators over each key diffirently & on each value diffirently
/// That - of course - is impossible
/// But it is actually possible with a custom data structure as shown here
/// 
/// It skips 2 teachers in the school and prints each student in reverse order
/// Why? Why not
/// 
/// (I should have been doing my homework not this)
/// </summary>

namespace VeryDumbProgrammingProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            School<Teacher> school = new School<Teacher>();
            school.Add(new Teacher(
                "Petya Vaneva",
                new Student("Tosho", 10),
                new Student("Stoyan", 12)));
            school.Add(new Teacher(
                "Ivan Dimitrov",
                new Student("Pesho", 7),
                new Student("Gosho", 8)));
            school.Add(new Teacher(
                "Viktor Dakov",
                new Student("Dimitrichko", 12)));

            foreach (Teacher teacher in school)
            {
                Console.WriteLine(teacher);
                foreach (Student student in teacher.Students)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}
