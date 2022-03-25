using System;
using System.Linq;

namespace ExtendedDatabase
{
    public class Database
    {
        private Person[] persons;

        private int count;

        public Database(params Person[] persons)
        {
            this.persons = new Person[16];
            AddRange(persons);
        }

        public int Count => count;

        private void AddRange(Person[] data)
        {
            if (data.Length > 16)
            {
                throw new ArgumentException("Provided data length should be in range [0..16]!");
            }

            for (int i = 0; i < data.Length; i++)
            {
                Add(data[i]);
            }

            count = data.Length;
        }

        public void Add(Person person)
        {
            if (count == 16)
            {
                throw new InvalidOperationException("Array's capacity must be exactly 16 integers!");
            }

            if (persons.Any(p => p?.UserName == person.UserName))
            {
                throw new InvalidOperationException("There is already user with this username!");
            }

            if (persons.Any(p => p?.Id == person.Id))
            {
                throw new InvalidOperationException("There is already user with this Id!");
            }

            persons[count] = person;
            count++;
        }

        public void Remove()
        {
            if (count == 0)
            {
                throw new InvalidOperationException();
            }

            count--;
            persons[count] = null;
        }

        public Person FindByUsername(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Username parameter is null!");
            }

            if (persons.Any(p => p?.UserName == name) == false)
            {
                throw new InvalidOperationException("No user is present by this username!");
            }

            Person person = persons.First(p => p.UserName == name);
            return person;
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id should be a positive number!");
            }

            if (persons.Any(p => p?.Id == id) == false)
            {
                throw new InvalidOperationException("No user is present by this ID!");
            }

            Person person = persons.First(p => p.Id == id);
            return person;
        }
    }
}
