using System;

namespace E06.OperationsBetweenNumbers {
    class Program {
        static void Main(string[] args) {
            double numberOne = double.Parse(Console.ReadLine());
            double numberTwo = double.Parse(Console.ReadLine());
            string numberOperator = Console.ReadLine();

            string everOdd = "";
            double result = 0.0;

            switch (numberOperator) {
                case "+":
                    result = numberOne + numberTwo;
                    if (result % 2 == 0) {
                        everOdd = "even"; 
                    } else {
                        everOdd = "odd";
                    }
                    Console.WriteLine($"{numberOne} + {numberTwo} = {result} - {everOdd}");
                    break;
                case "-":
                    result = numberOne - numberTwo;
                    if (result % 2 == 0) {
                        everOdd = "even";
                    } else {
                        everOdd = "odd";
                    }
                    Console.WriteLine($"{numberOne} - {numberTwo} = {result} - {everOdd}");
                    break;
                case "*":
                    result = numberOne * numberTwo;
                    if (result % 2 == 0) {
                        everOdd = "even";
                    } else {
                        everOdd = "odd";
                    }
                    Console.WriteLine($"{numberOne} * {numberTwo} = {result} - {everOdd}");
                    break;
                case "/":
                    if (numberTwo == 0) {
                        Console.WriteLine($"Cannot divide {numberOne} by zero");
                    } else {
                        result = numberOne / numberTwo;
                        Console.WriteLine($"{numberOne} / {numberTwo} = {result:f2}");
                    }
                    break;
                case "%":
                    if (numberTwo == 0) {
                        Console.WriteLine($"Cannot divide {numberOne} by zero");
                    } else {
                        result = numberOne % numberTwo;
                        Console.WriteLine($"{numberOne} % {numberTwo} = {result}");
                    }
                    break;
            }
        }
    }
}
