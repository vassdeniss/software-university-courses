using System.Collections.Generic;

namespace CollectionOfPersons
{
    public class PersonCollection : IPersonCollection
    {
        private readonly Dictionary<string, Person> peopleByEmail;
        private readonly Dictionary<string, SortedSet<Person>> peopleByEmailDomain;
        private readonly Dictionary<string, SortedSet<Person>> peopleByNameAndTown;
        private readonly Wintellect.PowerCollections.OrderedDictionary<int, SortedSet<Person>> peopleByAge;
        private readonly Dictionary<string, Wintellect.PowerCollections.OrderedDictionary<int, SortedSet<Person>>> peopleByTownAndAge;

        public PersonCollection()
        {
            this.peopleByEmail = new Dictionary<string, Person>();
            this.peopleByEmailDomain = new Dictionary<string, SortedSet<Person>>();
            this.peopleByNameAndTown = new Dictionary<string, SortedSet<Person>>();
            this.peopleByAge = new Wintellect.PowerCollections.OrderedDictionary<int, SortedSet<Person>>();
            this.peopleByTownAndAge = new Dictionary<string, Wintellect.PowerCollections.OrderedDictionary<int, SortedSet<Person>>>();
        }

        public bool AddPerson(string email, string name, int age, string town)
        {
            if (this.FindPerson(email) != null)
            {
                return false;
            }

            Person person = new Person(email, name, age, town);
            this.peopleByEmail.Add(email, person);
            this.peopleByEmailDomain.AppendValueToKey(ExtractEmailDomain(email), person);
            this.peopleByNameAndTown.AppendValueToKey($"{name}!{town}", person);
            this.peopleByAge.AppendValueToKey(age, person);
            this.peopleByTownAndAge.EnsureKeyExists(town);
            this.peopleByTownAndAge[town].AppendValueToKey(age, person);

            return true;
        }


        public int Count => this.peopleByEmail.Count;

        public Person FindPerson(string email)
        {
            this.peopleByEmail.TryGetValue(email, out Person person);
            return person;
        }

        public bool DeletePerson(string email)
        {
            Person person = this.FindPerson(email);
            if (person == null)
            {
                return false;
            }

            this.peopleByEmail.Remove(email);

            string domain = this.ExtractEmailDomain(email);
            this.peopleByEmailDomain[domain].Remove(person);

            this.peopleByNameAndTown[$"{person.Name}!{person.Town}"].Remove(person);

            this.peopleByAge[person.Age].Remove(person);

            this.peopleByTownAndAge[person.Town][person.Age].Remove(person);

            return true;
        }

        public IEnumerable<Person> FindPeople(string emailDomain)
        {
            return this.peopleByEmailDomain.GetValuesForKey(emailDomain);
        }

        public IEnumerable<Person> FindPeople(string name, string town)
        {
            return this.peopleByNameAndTown.GetValuesForKey($"{name}!{town}");
        }

        public IEnumerable<Person> FindPeople(int startAge, int endAge)
        {
            var peopleInRange = this.peopleByAge.Range(startAge, true, endAge, true);
            foreach (var personByAge in peopleInRange)
            {
                foreach (Person person in personByAge.Value)
                {
                    yield return person;
                }
            }
        }

        public IEnumerable<Person> FindPeople(int startAge, int endAge, string town)
        {
            if (!this.peopleByTownAndAge.ContainsKey(town))
            {
                yield break;
            }

            var peopleInRange = this.peopleByTownAndAge[town]
                .Range(startAge, true, endAge, true);
            foreach (var personByAge in peopleInRange)
            {
                foreach (Person person in personByAge.Value)
                {
                    yield return person;
                }
            }
        }

        private string ExtractEmailDomain(string email)
        {
            return email.Split('@')[1];
        }
    }
}
