using System;

namespace ME05.MultiplicationSign
{
    class Program
    {
        static void Sign(int n1, int n2, int n3)
        {
            int result = n1 * n2 * n3;
            if (result < 0)
                Console.WriteLine("negative");
            else if (result > 0)
                Console.WriteLine("positive");
            else
                Console.WriteLine("zero");
        }

        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Sign(num1, num2, num3);
        }
    }
}
