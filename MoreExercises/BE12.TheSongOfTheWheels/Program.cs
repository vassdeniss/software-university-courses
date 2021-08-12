using System;

namespace BE12.TheSongOfTheWheels {
    class Program {
        static void Main(string[] args) {
            int controlValue = int.Parse(Console.ReadLine());
            int magicNumber = 0;
            int counter = 0;
            string result = "";

            for (int i = 1111; i <= 9999; i++) {
                string currentNum = i.ToString();

                int currentNumOne = currentNum[0] - '0';
                int currentNumTwo = currentNum[1] - '0';
                int currentNumThree = currentNum[2] - '0';
                int currentNumFour = currentNum[3] - '0';

                bool checkOne = currentNumOne < currentNumTwo;
                bool checkTwo = currentNumThree > currentNumFour;
                bool checkThree =
                    currentNumOne * currentNumTwo
                    + currentNumThree * currentNumFour == controlValue;
                bool checkFour = currentNumOne != 0 && currentNumTwo != 0
                    && currentNumThree != 0 && currentNumFour != 0;

                if (checkOne && checkTwo && checkThree && checkFour) {
                    counter++;
                    result += $"{i} ";
                    if (counter == 4) { magicNumber = i; }
                }
            }

            if (magicNumber != 0) {
                Console.Write($"{result}\nPassword: {magicNumber}") ;
            } else { Console.Write($"{result}\nNo!"); }
        }
    }
}
