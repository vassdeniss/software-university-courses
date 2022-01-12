using System;
using System.Collections.Generic;

namespace L03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split();
            Stack<int> numbers = new Stack<int>();
            Stack<string> operators = new Stack<string>();

            foreach (string element in expression)
            {
                if (element == "+" || element == "-") operators.Push(element);
                else numbers.Push(int.Parse(element));

                if (numbers.Count > 1)
                {
                    int numOne = numbers.Pop();
                    int numTwo = numbers.Pop();
                    string operation = operators.Pop();
                    
                    if (operation == "+")
                    {
                        int n = numOne + numTwo;
                        numbers.Push(n);
                    }
                    else
                    {
                        int n = numTwo - numOne;
                        numbers.Push(n);
                    }
                }
            }

            Console.WriteLine(numbers.Pop());
        }
    }
}
