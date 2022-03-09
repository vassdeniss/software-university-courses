using E04.WildFarm.Contracts;
using E04.WildFarm.Models.Animals;
using System;

namespace E04.WildFarm.Factories
{
    public static class AnimalFactory
    {
        public static IAnimal CreateAnimal(string args)
        {
            string[] data = args.Split();

            string name = data[1];
            double weight = double.Parse(data[2]);  

            IAnimal animal = null;
            switch (data[0])
            {
                case "Cat":
                    animal = new Cat(name, weight, data[3], data[4]);
                    break;
                case "Dog":
                    animal = new Dog(name, weight, data[3]);
                    break;
                case "Hen":
                    animal = new Hen(name, weight, double.Parse(data[3]));
                    break;
                case "Mouse":
                    animal = new Mouse(name, weight, data[3]);
                    break;
                case "Owl":
                    animal = new Owl(name, weight, double.Parse(data[3]));
                    break;
                case "Tiger":
                    animal = new Tiger(name, weight, data[3], data[4]);
                    break;
            }

            return animal;
        }
    }
}
