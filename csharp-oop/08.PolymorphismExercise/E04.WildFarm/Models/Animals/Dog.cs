using E04.WildFarm.Contracts;
using E04.WildFarm.Models.Foods;
using System;

namespace E04.WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            :base(name, weight, livingRegion) { }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }

        public override void Feed(IFood food)
        {
            if (!(food is Meat))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }

            Weight += 0.4 * food.Quantity;
            FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
