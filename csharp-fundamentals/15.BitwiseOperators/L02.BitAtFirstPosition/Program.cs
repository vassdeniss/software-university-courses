using System;

namespace L02.BitAtFirstPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine((num >> 1) & 1);
        }
    }
}
