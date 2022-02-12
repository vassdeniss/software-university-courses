using System;

namespace E06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);
            return result == 0 ? Age.CompareTo(other.Age) : result;
        }

        public override bool Equals(object obj)
        {
            Person p = obj as Person;
            return Name == p.Name && Age == p.Age;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode();
        }
    }
}
