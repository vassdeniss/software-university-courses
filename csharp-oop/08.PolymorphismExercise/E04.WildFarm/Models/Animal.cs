using E04.WildFarm.Contracts;

namespace E04.WildFarm.Models
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set;   }

        public abstract void Feed(IFood food);

        public abstract void ProduceSound();
    }
}
