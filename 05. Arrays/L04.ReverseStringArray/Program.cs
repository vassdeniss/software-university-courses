using System;
using System.Linq;

namespace L04.ReverseStringArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringArray = Console.ReadLine().Split().ToArray();
            Array.Reverse(stringArray);
            foreach (string i in stringArray)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
