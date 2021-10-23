using System;

namespace E08.TriangleNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            if (num < 1 || num > 20) { return; }

            for (int i = 1; i <= num; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(i);

                    if (i > 1) { Console.Write(" "); }
                }

                Console.Write("\n");
            }
        }
    }
}
