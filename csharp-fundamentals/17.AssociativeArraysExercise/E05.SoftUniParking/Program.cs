using System;
using System.Collections.Generic;

namespace E05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandQty = int.Parse(Console.ReadLine());

            Dictionary<string, string> userRegistry = new Dictionary<string, string>();
            for (int i = 0; i < commandQty; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "register")
                    Register(input, userRegistry);
                else if (input[0] == "unregister")
                    Unregister(input, userRegistry);
            }

            foreach (KeyValuePair<string, string> pair in userRegistry)
                Console.WriteLine($"{pair.Key} => {pair.Value}");
        }

        static void Register(string[] input, Dictionary<string, string> dic)
        {
            string user = input[1];
            string plate = input[2];

            if (dic.ContainsKey(user))
                Console.WriteLine($"ERROR: already registered with plate number {dic[user]}");
            else
            {
                dic.Add(user, plate);
                Console.WriteLine($"{user} registered {plate} successfully");
            }
        }

        static void Unregister(string[] input, Dictionary<string, string> dic)
        {
            string user = input[1];

            if (dic.ContainsKey(user))
            {
                dic.Remove(user);
                Console.WriteLine($"{user} unregistered successfully");
            }
            else
                Console.WriteLine($"ERROR: user {user} not found");
        }
    }
}
