using E06.FoodShortage.Contracts;

namespace E06.FoodShortage.Models
{
    public class Citizen : IResident
    {
        private Citizen() => Food = 0;

        public Citizen(string name, string age, string id, string birthdate) : this()
        {
            Name = name;
            Age = age;
            Birthdate = birthdate;
            ID = id;
        }

        public string Name { get; private set; }

        public string Age { get; private set; }

        public string Birthdate { get; private set; }

        public string ID { get; private set; }

        public int Food { get; private set; }

        public void BuyFood() => Food += 10;
    }
}
