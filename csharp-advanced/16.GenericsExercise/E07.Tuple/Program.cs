using System;

namespace E07.Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data;

            data = Console.ReadLine().Split();
            Console.WriteLine(new CustomTuple<string, string>(data[0] + " " + data[1], data[2]));

            data = Console.ReadLine().Split();
            Console.WriteLine(new CustomTuple<string, int>(data[0], int.Parse(data[1])));

            data = Console.ReadLine().Split();
            Console.WriteLine(new CustomTuple<int, double>(int.Parse(data[0]), double.Parse(data[1])));
        }
    }
}
