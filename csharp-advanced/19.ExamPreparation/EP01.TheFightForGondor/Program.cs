using System;
using System.Collections.Generic;
using System.Linq;

namespace EP01.TheFightForGondor
{
    enum OrcAttack
    {
        HIGHER,
        LOWER,
        EQUAL
    }

    internal class Program
    {
        private static Stack<int> Plates;
        private static Stack<int> Orcs;

        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            Plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).Reverse());
            Orcs = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                IEnumerable<int> orcsArray = Console.ReadLine().Split().Select(int.Parse);
                foreach (int orc in orcsArray) Orcs.Push(orc);

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    List<int> tmpPlates = Plates.ToList();
                    tmpPlates.Add(newPlate);
                    tmpPlates.Reverse();
                    Plates = new Stack<int>(tmpPlates);
                }

                while (Plates.Count > 0 && Orcs.Count > 0)
                {
                    int orc = Orcs.Pop();
                    int plate = Plates.Pop();

                    OrcAttack attackType = CheckAttack(orc, plate);
                    if (attackType == OrcAttack.HIGHER)
                        Orcs.Push(orc -= plate);
                    else if (attackType == OrcAttack.LOWER)
                        Plates.Push(plate -= orc);
                }

                if (Plates.Count <= 0) break;
            }

            if (Plates.Any())
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", Plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", Orcs)}");
            }
        }

        private static OrcAttack CheckAttack(int orc, int plate)
        {
            if (orc > plate)
            {
                return OrcAttack.HIGHER;
            }
            
            if (orc < plate)
            {
                return OrcAttack.LOWER;
            }

            return OrcAttack.EQUAL;
        }
    }
}
