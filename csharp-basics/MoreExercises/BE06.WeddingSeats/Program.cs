using System;

namespace BE06.WeddingSeats {
    class Program {
        static void Main(string[] args) {
            char lastSection = char.Parse(Console.ReadLine());
            int firstSectionRows = int.Parse(Console.ReadLine());
            int oddSeatsNum = int.Parse(Console.ReadLine());
            int totalSeats = 0;
            bool isIncreased = false;

            for (int i = 'A'; i <= lastSection; i++) {
                char upperLetter = Convert.ToChar(i);
                for (int j = 1; j <= firstSectionRows; j++) {
                    char lowerLetter = Convert.ToChar(97);
                    if (j % 2 == 0) {
                        oddSeatsNum += 2; isIncreased = true;
                    }

                    for (int k = 0; k < oddSeatsNum; k++) {
                        Console.WriteLine($"{upperLetter}{j}{lowerLetter}");
                        lowerLetter++;
                        totalSeats++;
                    }

                    if (isIncreased) { 
                        oddSeatsNum -= 2; isIncreased = false;  
                    }
                }
                firstSectionRows++;
            }
            Console.WriteLine(totalSeats);
        }
    }
}
