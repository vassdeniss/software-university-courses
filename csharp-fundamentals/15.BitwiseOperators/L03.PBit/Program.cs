using System;

namespace L03.PBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int shift = int.Parse(Console.ReadLine());
            Console.WriteLine((num >>= shift) & 1);
        }
    }
}
