using System;

namespace L04.EvenPowersOfTwo {
    class Program {
        static void Main(string[] args) {
            int power = int.Parse(Console.ReadLine()); 

            for (int i = 0; i <= power; i+=2 ) {
                Console.WriteLine(Math.Pow(2, i));
            }
        }
    }
}
