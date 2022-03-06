using E09.ExplicitInterfaces.Contracts;
using E09.ExplicitInterfaces.Models;
using System;

namespace E09.ExplicitInterfaces.Core
{
    public class Engine : IRunnable
    {
        public Engine() { }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input.Split();
                Citizen citizen = new Citizen(tokens[0], tokens[1], tokens[2]);
                Console.WriteLine(citizen);
                input = Console.ReadLine();
            }
        }
    }
}
