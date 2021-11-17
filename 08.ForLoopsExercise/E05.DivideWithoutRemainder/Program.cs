using System;

namespace E05.DivideWithoutRemainder {
    class Program {
        static void Main(string[] args) {
            double numberQty = double.Parse(Console.ReadLine());
            int groupOne = 0;
            int groupTwo = 0;
            int groupThree = 0;;

            for (int i = 0; i < numberQty; i++) {
                double number = double.Parse(Console.ReadLine());
                if (number % 2 == 0) { groupOne++; } 
                if (number % 3 == 0) { groupTwo++; } 
                if (number % 4 == 0) { groupThree++; } 
            }

            double percentOne = (groupOne / numberQty) * 100;
            double percentTwo = (groupTwo / numberQty) * 100;
            double percentThree = (groupThree / numberQty) * 100;

            Console.WriteLine(
                $"{percentOne:f2}%\n" +
                $"{percentTwo:f2}%\n" +
                $"{percentThree:f2}%"
            );
        }
    }
}
