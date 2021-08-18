using System;

namespace EP06.BarcodeGenerator {
    class Program {
        static void Main(string[] args) {
            string numberOne = Console.ReadLine();
            string numberTwo = Console.ReadLine();

            int numOneA = int.Parse(numberOne[0].ToString());
            int numTwoA = int.Parse(numberOne[1].ToString());
            int numThreeA = int.Parse(numberOne[2].ToString());
            int numFourA = int.Parse(numberOne[3].ToString());

            int numOneB = int.Parse(numberTwo[0].ToString());
            int numTwoB = int.Parse(numberTwo[1].ToString());
            int numThreeB = int.Parse(numberTwo[2].ToString());
            int numFourB = int.Parse(numberTwo[3].ToString());


            for (int i = numOneA; i <= numOneB; i++) {
                for (int j = numTwoA; j <= numTwoB; j++) {
                    for (int k = numThreeA; k <= numThreeB; k++) {
                        for (int m = numFourA; m <= numFourB; m++) {
                            bool checkOne = i % 2 != 0;
                            bool checkTwo = j % 2 != 0;
                            bool checkThree = k % 2 != 0;
                            bool checkFour = m % 2 != 0;

                            if (checkOne && checkTwo
                                && checkThree && checkFour) {
                                Console.Write($"{i}{j}{k}{m} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
