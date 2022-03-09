using E04.WildFarm.Contracts;
using E04.WildFarm.Factories;
using System;
using System.Collections.Generic;

namespace E04.WildFarm.Core
{
    public class Engine : IRunnable
    {
        private readonly LinkedList<IAnimal> animals;

        public Engine()
        {
            animals = new LinkedList<IAnimal>();
        }

        public void Run()
        {
            int counter = 0;
            
            string input = Console.ReadLine();
            while (input != "End")
            {
                if (counter++ % 2 == 0)
                {
                    IAnimal animal = AnimalFactory.CreateAnimal(input);
                    animals.AddLast(animal);
                    animal.ProduceSound();
                }
                else
                {
                    IFood food = FoodFactory.CreateFood(input);
                    IAnimal animal = animals.Last.Value;

                    try
                    {
                        animal.Feed(food);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                input = Console.ReadLine();
            }

            LinkedListNode<IAnimal> head = animals.First;
            while (head != null)
            {
                Console.WriteLine(head.Value);
                head = head.Next;
            }
        }
    }
}
