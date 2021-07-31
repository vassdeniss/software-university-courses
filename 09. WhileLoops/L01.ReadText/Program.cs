using System;

namespace L01.ReadText {
    class Program {
        static void Main(string[] args) {
            string input = Console.ReadLine();

            while (input != "Stop") {
                Console.WriteLine(input);
                input = Console.ReadLine();
            }
        }
    }
}
