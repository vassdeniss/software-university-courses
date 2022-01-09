using System;

namespace BE07.FootballLeague {
    class Program {
        static void Main(string[] args) {
            double stadiumCapacity = double.Parse(Console.ReadLine());
            double fanQty = double.Parse(Console.ReadLine());

            double percentA = 0;
            double percentB = 0;
            double percentV = 0;
            double percentG = 0;
            double totalPercent = 0;

            for (int i = 0; i < fanQty; i++) {
                string fanSector = Console.ReadLine();
                if (fanSector == "A") { percentA++; } 
                else if (fanSector == "B") { percentB++; } 
                else if (fanSector == "V") { percentV++; }
                else if (fanSector == "G") { percentG++; }
            }

            percentA = (percentA / fanQty) * 100;
            percentB = (percentB / fanQty) * 100;
            percentV = (percentV / fanQty) * 100;
            percentG = (percentG / fanQty) * 100;
            totalPercent = (fanQty / stadiumCapacity) * 100;

            Console.WriteLine($"{percentA:f2}%");
            Console.WriteLine($"{percentB:f2}%");
            Console.WriteLine($"{percentV:f2}%");
            Console.WriteLine($"{percentG:f2}%");
            Console.WriteLine($"{totalPercent:f2}%");
        }
    }
}
