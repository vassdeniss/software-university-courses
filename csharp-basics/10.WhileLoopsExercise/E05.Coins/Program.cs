using System;

namespace E05.Coins {
    class Program {
        static void Main(string[] args) {
            double change = double.Parse(Console.ReadLine());
            int requiredCoins = 0;

            int wholeChange = (int)(change * 100);

            while (wholeChange > 0) {
                if (wholeChange - 200 >= 0) {
                    requiredCoins++;
                    wholeChange -= 200;
                } else if (wholeChange - 100 >= 0) {
                    requiredCoins++;
                    wholeChange -= 100;
                } else if (wholeChange - 50 >= 0) {
                    requiredCoins++;
                    wholeChange -= 50;
                } else if (wholeChange - 20 >= 0) {
                    requiredCoins++;
                    wholeChange -= 20;
                } else if (wholeChange - 10 >= 0) {
                    requiredCoins++;
                    wholeChange -= 10;
                } else if (wholeChange - 5 >= 0) {
                    requiredCoins++;
                    wholeChange -= 5;
                } else if (wholeChange - 2 >= 0) {
                    requiredCoins++;
                    wholeChange -= 2;
                } else if (wholeChange - 1 >= 0) {
                    requiredCoins++;
                    wholeChange -= 1;
                }
            }

            Console.WriteLine(requiredCoins);
        }
    }
}
