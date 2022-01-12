using System;
using System.Collections.Generic;

namespace L04.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> bracketIndices = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(') bracketIndices.Push(i);

                if (expression[i] == ')')
                {
                    int opening = bracketIndices.Pop();
                    int closing = i + 1;

                    Console.WriteLine(expression.Substring(opening, closing - opening));
                }
            }
        }
    }
}
