using System;

namespace BE07.SafePasswordsGenerator {
    class Program {
        static void Main(string[] args) {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxGenerations = int.Parse(Console.ReadLine());

            char aChar = Convert.ToChar(35);
            char bChar = Convert.ToChar(64);

            for (int k = 1; k <= a; k++) {
                for (int m = 1; m <= b; m++) {
                    if (maxGenerations == 0) { return; }
                    Console.Write($"{aChar}{bChar}{k}{m}{bChar}{aChar}|");
                    maxGenerations--;
                    aChar++;
                    bChar++;
                    if (aChar > 55) { aChar = Convert.ToChar(35); }
                    if (bChar > 96) { bChar = Convert.ToChar(64); }
                }
            }
        }
    }
}
