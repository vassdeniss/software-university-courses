using System;
using System.Linq;

namespace L03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpper = x => char.IsUpper(x[0]);
            string[] text = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => isUpper(x)).ToArray();

            Print(text, x => Console.WriteLine(x));
        }

        private static void Print(string[] arr, Action<string> callback)
        {
            foreach (string s in arr)
            {
                callback(s);
            }
        }
    }
}
