using E05.BirthdayCelebrations.Contracts;

namespace E05.BirthdayCelebrations.Models
{
    public class Citizen : IResident, IHuman
    {
        public Citizen(string name, string age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            ID = id;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Age { get; private set; }

        public string ID { get; private set; }

        public string Birthdate { get; private set; }
    }
}
