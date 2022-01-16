using System;
using System.Collections.Generic;

namespace E08.BalancedParentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();

            Stack<char> parenthesesStack = new Stack<char>();
            foreach (char parentheses in sequence)
            {
                if (parentheses == '(' || parentheses == '{' || parentheses == '[')
                    parenthesesStack.Push(parentheses);

                if (parenthesesStack.Count == 0)
                {
                    Console.WriteLine("NO");
                    return;
                }

                char compare = parenthesesStack.Peek();
                if (compare == '(' && parentheses == ')' 
                    || compare == '{' && parentheses == '}' 
                    || compare == '[' && parentheses == ']'
                ) parenthesesStack.Pop();
            }

            Console.WriteLine(parenthesesStack.Count == 0 ? "YES" : "NO");
        }
    }
}
