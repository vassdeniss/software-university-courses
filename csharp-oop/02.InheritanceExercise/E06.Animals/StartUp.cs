using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string type = Console.ReadLine();

                if (type == "Beast!") break;

                Console.WriteLine(type);

                string[] tokens = Console.ReadLine().Split();
                Console.WriteLine(string.Join(" ", tokens));

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = tokens[2];

                Animal animal = default;
                switch (type)
                {
                    case "Dog":
                        animal = new Dog(name, age, gender);
                        break;
                    case "Cat":
                        animal = new Cat(name, age, gender);
                        break;
                    case "Frog":
                        animal = new Frog(name, age, gender);
                        break;
                    case "Kittens":
                        animal = new Kitten(name, age);
                        break;
                    case "Tomcat":
                        animal = new Tomcat(name, age);
                        break;
                }

                Console.WriteLine(type);
                Console.WriteLine(string.Join(" ", tokens));
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
