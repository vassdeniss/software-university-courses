using System;
using System.Collections.Generic;

namespace E03.HouseParty
{
    class Program
    {
        static bool isOnList(List<string> list, string name)
        {
            foreach (string s in list)
                if (name == s)
                    return true;
            return false;
        }

        static void Main(string[] args)
        {
            List<string> questList = new List<string>();
            int commandsQuantity = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsQuantity; i++)
            {
                string[] comment = Console.ReadLine().Split();
                string name = comment[0];
                bool isPersonThere = isOnList(questList, name);

                if (comment[2] == "not")
                {
                    if (isPersonThere)
                        questList.Remove(name);
                    else if (!isPersonThere)
                        Console.WriteLine($"{name} is not in the list!");
                }
                else
                {
                    if (!isPersonThere)
                        questList.Add(name);
                    else if (isPersonThere)
                        Console.WriteLine($"{name} is already in the list!");
                }
            }

            foreach (string s in questList)
                Console.WriteLine(s);
        }
    }
}
