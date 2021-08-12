using System;

namespace BE02.LettersCombinations {
    class Program {
        static void Main(string[] args) {
            char startLetter = char.Parse(Console.ReadLine());
            char endLetter = char.Parse(Console.ReadLine());
            char skippedLetter = char.Parse(Console.ReadLine());
            int totalCombinations = 0;

            for (char i = startLetter; i <= endLetter; i++) {
                for (char j = startLetter; j <= endLetter; j++) {
                    for (char k = startLetter; k <= endLetter; k++) {
                        if (i != skippedLetter 
                            && j != skippedLetter
                            && k != skippedLetter) {
                            totalCombinations++;
                            Console.Write($"{i}{j}{k} ");
                        }
                    }
                }
            }
            Console.Write(totalCombinations);
        }
    }
}
