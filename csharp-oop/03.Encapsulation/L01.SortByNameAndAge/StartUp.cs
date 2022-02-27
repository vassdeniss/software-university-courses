using System;
using System.Collections.Generic;
using System.Linq;

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
                Person person = new Person(cmd[0], cmd[1], int.Parse(cmd[2]));
                persons.Add(person);
            }

            persons.OrderBy(p => p.FirstName).ThenBy(p => p.Age)
                   .ToList().ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
