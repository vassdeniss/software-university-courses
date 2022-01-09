using System;

namespace E04.Histogram {
    class Program {
        static void Main(string[] args) {
            double numberQty = double.Parse(Console.ReadLine());
            int groupOne = 0;
            int groupTwo = 0;
            int groupThree = 0;
            int groupFour = 0;
            int groupFive = 0;

            for (int i = 0; i < numberQty; i++) {
                double number = double.Parse(Console.ReadLine());
                if (number < 200) { groupOne++; } 
                else if (number >= 200 && number <= 399) { groupTwo++; }
                else if (number >= 400 && number <= 599) { groupThree++; }
                else if (number >= 600 && number <= 799) { groupFour++; }
                else if (number >= 800) { groupFive++; }
            }

            double percentOne = (groupOne / numberQty) * 100;
            double percentTwo = (groupTwo / numberQty) * 100;
            double percentThree = (groupThree / numberQty) * 100;
            double percentFour = (groupFour / numberQty) * 100;
            double percentFive = (groupFive / numberQty) * 100;

            Console.WriteLine(
                $"{percentOne:f2}%\n" +
                $"{percentTwo:f2}%\n" + 
                $"{percentThree:f2}%\n" + 
                $"{percentFour:f2}%\n" + 
                $"{percentFive:f2}%"
            );
        }
    }
}
