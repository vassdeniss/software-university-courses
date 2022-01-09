using System;
using System.Collections.Generic;
using System.Linq;

namespace ME02.OldestFamilyMember
{
    class Family
    {
        private List<Person> familyList_ = new List<Person>();

        public void AddMember(Person member)
        {
            familyList_.Add(member);
        }

        public Person GetOldestMember()
        {
            int oldestAge = familyList_.Max(member => member.Age);
            return familyList_.Find(member => member.Age == oldestAge);
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }
        public int Age { get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int memberQty = int.Parse(Console.ReadLine());

            Family family = new Family();
            for (int i = 0; i < memberQty; i++)
            {
                string[] data = Console.ReadLine().Split();

                string name = data[0];
                int age = int.Parse(data[1]);

                Person newMember = new Person(name, age);
                family.AddMember(newMember);
            }

            Person oldestPerson = family.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
