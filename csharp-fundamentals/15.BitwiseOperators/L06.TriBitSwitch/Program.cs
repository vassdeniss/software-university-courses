using System;

namespace L06.TriBitSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int shift = int.Parse(Console.ReadLine());

            int mask = 7 << shift;

            Console.WriteLine(input ^ mask);
        }
    }
}
