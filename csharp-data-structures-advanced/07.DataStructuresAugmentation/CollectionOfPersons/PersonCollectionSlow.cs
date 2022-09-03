using System.Collections.Generic;
using System.Linq;

namespace CollectionOfPersons
{
    public class PersonCollectionSlow : IPersonCollection
    {
        private readonly List<Person> persons;

        public PersonCollectionSlow()
        {
            this.persons = new List<Person>();
        }

        public bool AddPerson(string email, string name, int age, string town)
        {
            if (this.FindPerson(email) != null)
            {
                return false;
            }

            this.persons.Add(new Person(email, name, age, town));
            return true;
        }

        public int Count => this.persons.Count;

        public Person FindPerson(string email)
        {
            return this.persons.FirstOrDefault(p => p.Email == email);
        }

        public bool DeletePerson(string email)
        {
            return this.persons.Remove(this.FindPerson(email));
        }

        public IEnumerable<Person> FindPeople(string emailDomain)
        {
            return this.persons
                .Where(p => p.Email.EndsWith($"@{emailDomain}"))
                .OrderBy(p => p.Email);
        }

        public IEnumerable<Person> FindPeople(string name, string town)
        {
            return this.persons
                .Where(p => p.Name == name && p.Town == town)
                .OrderBy(p => p.Email);
        }

        public IEnumerable<Person> FindPeople(int startAge, int endAge)
        {
            return this.persons
                .Where(p => p.Age >= startAge && p.Age <= endAge)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);
        }

        public IEnumerable<Person> FindPeople(int startAge, int endAge, string town)
        {
            return this.persons
                .Where(p => p.Town == town && p.Age >= startAge && p.Age <= endAge)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);
        }
    }
}
