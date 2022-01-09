using System;

namespace ME01.DataTypes
{
    class Program
    {
        static int GetType(int n) { return n * 2; }
        static double GetType(double d) { return d * 1.5; }
        static string GetType(string s) { return $"${s}$"; }

        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string input = Console.ReadLine();

            if (type == "int")
            {
                Console.WriteLine(GetType(int.Parse(input)));
            }
            else if (type == "real")
            {
                Console.WriteLine($"{GetType(double.Parse(input)):f2}");
            }
            else
            {
                Console.WriteLine(GetType(input));
            }
        }
    }
}
