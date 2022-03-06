using E09.ExplicitInterfaces.Contracts;

namespace E09.ExplicitInterfaces.Models
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name { get; private set; }

        public string Age { get; private set; }

        public string Country { get; private set; }

        string IPerson.GetName()
        {
            return Name;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }

        public override string ToString()
        {
            return $"{(this as IPerson).GetName()}\n{(this as IResident).GetName()}";
        }
    }
}
