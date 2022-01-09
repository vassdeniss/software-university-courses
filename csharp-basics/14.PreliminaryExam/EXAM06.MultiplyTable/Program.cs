using System;

namespace EXAM06.MultiplyTable {
    class Program {
        static void Main(string[] args) {
            string input = Console.ReadLine();

            int numOne = int.Parse(input[2].ToString());
            int numTwo = int.Parse(input[1].ToString());
            int numThree = int.Parse(input[0].ToString());

            for (int i = 1; i <= numOne; i++) {
                for (int j = 1; j <= numTwo; j++) {
                    for (int k = 1; k <= numThree; k++) {
                        Console.WriteLine($"{i} * {j} * {k} " +
                            $"= {i * j * k};");
                    }
                }
            }
        }
    }
}
