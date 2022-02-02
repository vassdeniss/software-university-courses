using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;
        private static List<Person> people = new List<Person>();

        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int age) : this()
        {
            Age = age;
        }

        public Person(string name, int age) : this(age)
        {
            Name = name;
        }

        public string Name 
        { 
            get { return name; } 
            private set{ name = value; }
        }

        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        public static void AddPerson(Person person)
        {
            people.Add(person);
        }

        public static void FilterAndPrint()
        {
            people = people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
            people.ForEach(x => Console.WriteLine(x));
        }

        public override string ToString()
        {
            return $"{name} - {age}";
        }
    }
}
