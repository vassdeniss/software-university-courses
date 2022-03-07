using Animals.Contracts;
using Animals.Models;
using System;

namespace Animals.Core
{
    public class Engine : IRunnable
    {
        public void Run()
        {
            Animal cat = new Cat("Peter", "Whiskas");
            Animal dog = new Dog("George", "Meat");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());
        }
    }
}
