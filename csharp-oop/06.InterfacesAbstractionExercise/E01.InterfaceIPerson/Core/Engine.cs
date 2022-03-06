using PersonInfo.Contracts;
using PersonInfo.Models;
using System;

namespace PersonInfo.Core
{
    public class Engine : IRunnable
    {
        public void Run()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            IPerson person = new Citizen(name, age);

            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}
