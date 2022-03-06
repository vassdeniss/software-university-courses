using E04.BorderControl.Contracts;

namespace E04.BorderControl.Models
{
    public class Citizen : IResident, IHuman
    {
        public Citizen(string name, string age, string id)
        {
            Name = name;
            Age = age;
            ID = id;
        }

        public string Name { get; private set; }

        public string Age { get; private set; }

        public string ID { get; private set; }
    }
}
