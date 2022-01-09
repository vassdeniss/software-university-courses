using System;
using System.Linq;

namespace L05.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Where(word => word.Length % 2 == 0).ToArray();

            foreach (string s in input)
                Console.WriteLine(s);
        }
    }
}
