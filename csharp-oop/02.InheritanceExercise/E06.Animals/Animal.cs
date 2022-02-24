using System;

namespace Animals
{
    public abstract class Animal
    {
        public Animal(string name, int age, string gender)
        {
            try
            {
                Name = name;
                Age = age;
                Gender = gender;
            } 
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
            }
        }

        public string Name { get; set; }
        public int Age { get; protected set; }
        public string Gender { get; protected set; }

        public abstract string ProduceSound();
    }
}
