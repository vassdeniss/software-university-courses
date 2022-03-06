using E06.FoodShortage.Contracts;

namespace E06.FoodShortage.Models
{
    public class Rebel : IResident
    {
        private Rebel() => Food = 0;

        public Rebel(string name, string age, string group) : this()
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; private set; }

        public string Age { get; private set; }

        public string Group { get; private set; }

        public int Food { get; private set; }

        public void BuyFood() => Food += 5;
    }
}
