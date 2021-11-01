using System;
using System.Collections.Generic;
using System.Linq;

namespace E07.OrderByAge
{
    class Program
    {
        internal class Person
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public int Age { get; set; }

            public override string ToString()
            {
                return $"{Name} with ID: {ID} is {Age} years old.";
            }
        }

        static void Main(string[] args)
        {
            string[] cmd = Console.ReadLine().Split();

            List<Person> peopleList = new List<Person>();
            while (cmd[0] != "End")
            {
                string name = cmd[0];
                string id = cmd[1];
                int age = int.Parse(cmd[2]);

                Person existingPerson = peopleList.FirstOrDefault(person => person.ID == id);

                if (existingPerson == null)
                {
                    peopleList.Add(new Person()
                    {
                        Name = name,
                        ID = id,
                        Age = age
                    });
                }
                else
                {
                    existingPerson.Age = age;
                    existingPerson.Name = name;
                }

                cmd = Console.ReadLine().Split();
            }

            foreach (Person person in peopleList.OrderBy(person => person.Age))
                Console.WriteLine(person);
        }
    }
}
