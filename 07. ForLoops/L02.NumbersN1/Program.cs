using System;

namespace L02.NumbersN1 {
    class Program {
        static void Main(string[] args) {
            int num = int.Parse(Console.ReadLine()); 

            for (int i = num; i > 0; i--) {
                Console.WriteLine(i);
            }
        }
    }
}
