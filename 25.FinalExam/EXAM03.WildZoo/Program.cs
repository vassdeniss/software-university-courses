using System;
using System.Collections.Generic;
using System.Linq;

namespace EXAM03.WildZoo
{
    class Animal
    {
        public Animal(string name, int foodQty, string area)
        {
            Name = name;
            FoodQty = foodQty;
            Area = area;
        }

        public string Name { get; set; }
        public int FoodQty { get; set; }
        public string Area { get; set; }

        public override string ToString()
        {
            return $" {Name} -> {FoodQty}g";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animalList = new List<Animal>();
            Dictionary<string, int> areaList = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "EndDay")
            {
                string[] cmd = input.Split(new string[] { ": ", "-" }, StringSplitOptions.None);
                if (cmd[0] == "Add")
                {
                    string name = cmd[1];
                    int food = int.Parse(cmd[2]);
                    string area = cmd[3];

                    Animal newAnimal = new Animal(name, food, area);
                    bool hasAnimal = animalList.Exists(x => x.Name == name);
                    if (hasAnimal)
                    {
                        int index = animalList.IndexOf(animalList.Find(x => x.Name == name));
                        animalList[index].FoodQty += food;
                    }
                    else
                    {
                        animalList.Add(newAnimal);
                        if (!areaList.ContainsKey(area)) areaList.Add(area, 1);
                        else areaList[area]++;
                    }
                }
                else if (cmd[0] == "Feed")
                {
                    string name = cmd[1];
                    int food = int.Parse(cmd[2]);

                    Animal animal = animalList.FirstOrDefault(x => x.Name == name);
                    if (animal != null && animalList.Contains(animal))
                    {
                        int index = animalList.IndexOf(animal);
                        animalList[index].FoodQty -= food;
                        if (animalList[index].FoodQty <= 0)
                        {
                            animalList.RemoveAt(index);
                            areaList[animal.Area]--;
                            Console.WriteLine($"{name} was successfully fed");
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Animals:");
            foreach (Animal animal in animalList.OrderByDescending(x => x.FoodQty).ThenBy(x => x.Name))
                Console.WriteLine(animal);

            Console.WriteLine("Areas with hungry animals:");
            foreach (KeyValuePair<string, int> pair in areaList.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                if (pair.Value > 0) Console.WriteLine($" {pair.Key}: {pair.Value}");
        }
    }
}
