using System.Collections.Generic;

namespace CollectionOfPersons
{
    public interface IPersonCollection
    {
        bool AddPerson(string email, string name, int age, string town);

        int Count { get; }

        Person FindPerson(string email);

        bool DeletePerson(string email);

        IEnumerable<Person> FindPeople(string emailDomain);

        IEnumerable<Person> FindPeople(string name, string town);

        IEnumerable<Person> FindPeople(int startAge, int endAge);

        IEnumerable<Person> FindPeople(int startAge, int endAge, string town);
    }
}
