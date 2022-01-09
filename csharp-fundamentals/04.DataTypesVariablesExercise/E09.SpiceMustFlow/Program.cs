using System;

namespace E09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());

            int daysOperated = 0;
            int spiceExtracted = 0;
            int takenSpice = 0;

            while (yield >= 100)
            {
                daysOperated++;
                spiceExtracted += yield;
                if (spiceExtracted >= 26) { takenSpice += 26; }
                yield -= 10;
            }

            if (spiceExtracted >= 26) { takenSpice += 26; }
            spiceExtracted -= takenSpice;

            Console.WriteLine($"{daysOperated}\n{spiceExtracted}");
        }
    }
}
