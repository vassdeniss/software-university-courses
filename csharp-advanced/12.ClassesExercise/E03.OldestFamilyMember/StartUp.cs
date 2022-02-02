using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int qty = int.Parse(Console.ReadLine());
            for (int i = 0; i < qty; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                int age = int.Parse(data[1]);

                family.AddMember(new Person(name, age));
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
