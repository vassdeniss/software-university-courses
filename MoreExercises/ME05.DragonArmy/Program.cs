using System;
using System.Collections.Generic;
using System.Linq;

namespace ME05.DragonArmy
{
    class Dragon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }

        public override string ToString()
        {
            return $"-{Name} -> damage: {Damage}, health: {Health}, armor: {Armor}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Dragon>> dragons = new Dictionary<string, List<Dragon>>();

            RegisterDragons(dragons, int.Parse(Console.ReadLine()));

            foreach (KeyValuePair<string, List<Dragon>> type in dragons)
            {
                double avgDamage = type.Value.Average(x => x.Damage);
                double avgHealth = type.Value.Average(x => x.Health);
                double avgArmor = type.Value.Average(x => x.Armor);

                Console.WriteLine($"{type.Key}::({avgDamage:f2}/{avgHealth:f2}/{avgArmor:f2})");
                foreach (Dragon derg in type.Value.OrderBy(x => x.Name)) Console.WriteLine(derg);
            }
        }

        private static void RegisterDragons(Dictionary<string, List<Dragon>> dragons, int dragonQty)
        {
            for (int i = 0; i < dragonQty; i++)
            {
                string[] data = Console.ReadLine().Split();

                string type = data[0];
                string name = data[1];
                string damageString = data[2];
                string healthString = data[3];
                string armorString = data[4];

                int damage;
                if (damageString == "null") damage = 45;
                else damage = int.Parse(damageString);

                int health;
                if (healthString == "null") health = 250;
                else health = int.Parse(healthString);

                int armor;
                if (armorString == "null") armor = 10;
                else armor = int.Parse(armorString);

                if (dragons.ContainsKey(type))
                {
                    bool repeatDragon = false;
                    foreach (Dragon derg in dragons[type])
                    {
                        if (derg.Name == name)
                        {
                            int index = dragons[type].IndexOf(derg);
                            dragons[type][index].Damage = damage;
                            dragons[type][index].Health = health;
                            dragons[type][index].Armor = armor;
                            repeatDragon = true;
                            break;
                        }
                    }

                    if (!repeatDragon)
                    {
                        dragons[type].Add(new Dragon()
                        {
                            Name = name,
                            Damage = damage,
                            Health = health,
                            Armor = armor
                        });
                    }
                }
                else
                {
                    dragons.Add(type, new List<Dragon>()
                    {
                        new Dragon()
                        {
                            Name = name,
                            Damage = damage,
                            Health = health,
                            Armor = armor
                        }
                    });
                }
            }
        }
    }
}