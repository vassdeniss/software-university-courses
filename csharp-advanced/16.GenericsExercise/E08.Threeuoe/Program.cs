using System;

namespace E08.Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data;

            data = Console.ReadLine().Split();
            string name = $"{data[0]} {data[1]}";
            string address = data[2];
            string town = string.Join(" ", data[3..^0]);
            Console.WriteLine(new Threeuple<string, string, string>(name, address, town));

            data = Console.ReadLine().Split();
            string secondName = data[0];
            int qty = int.Parse(data[1]);
            bool isDrunk = data[2] == "drunk";
            Console.WriteLine(new Threeuple<string, int, string>(secondName, qty, isDrunk.ToString()));

            data = Console.ReadLine().Split();
            string thirdName = data[0];
            double balance = double.Parse(data[1]);
            string bank = data[2];
            Console.WriteLine(new Threeuple<string, double, string>(thirdName, balance, bank));
        }
    }
}
