using System;
using System.Collections.Generic;

namespace E05.ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split();
                people.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
                input = Console.ReadLine();
            }

            int equal = 0;
            int lower = 0;

            Person comparePerson = people[int.Parse(Console.ReadLine()) - 1];
            foreach (Person person in people)
            {
                if (comparePerson.CompareTo(person) == 0) equal++;
                else lower++;
            }

            Console.WriteLine(equal > 1
                ? $"{equal} {lower} {people.Count}"
                : "No matches");
        }
    }
}
