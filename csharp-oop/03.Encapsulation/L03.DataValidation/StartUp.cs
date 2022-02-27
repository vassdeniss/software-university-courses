using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                string[] cmd = Console.ReadLine().Split();
                Person person = new Person(cmd[0], cmd[1], int.Parse(cmd[2]), decimal.Parse(cmd[3]));
                persons.Add(person);
            }

            decimal parcentage = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(parcentage));
            persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
