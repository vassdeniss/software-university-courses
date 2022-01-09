using System;
using System.Collections.Generic;
using System.Linq;

namespace EP02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoin = 0;
            int rooms = 0;

            List<string> cmd = Console.ReadLine()
                .Split(new[] { '|', ' ' }).ToList();

            for (int i = 0; i < cmd.Count; i++)
            {
                if (cmd[i] == "potion")
                {
                    i++;
                    int healAmount = int.Parse(cmd[i]);
                    int oldHealth = health;
                    health += healAmount;
                    if (health > 100)
                    {
                        health = 100; healAmount = 100 - oldHealth;
                    }
                    Console.WriteLine($"You healed for {healAmount} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                    rooms++;
                }
                else if (cmd[i] == "chest")
                {
                    i++;
                    int amount = int.Parse(cmd[i]);
                    bitcoin += amount;
                    Console.WriteLine($"You found {amount} bitcoins.");
                    rooms++;
                }
                else
                {
                    string monsterName = cmd[i];
                    i++;
                    int damage = int.Parse(cmd[i]);
                    health -= damage;
                    rooms++;
                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {monsterName}.");
                        Console.WriteLine($"Best room: {rooms}");
                        return;
                    }
                    Console.WriteLine($"You slayed {monsterName}.");
                }
            }

            Console.WriteLine($"You've made it!\nBitcoins: {bitcoin}\nHealth: {health}");
        }
    }
}
