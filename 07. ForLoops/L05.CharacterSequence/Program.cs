using System;

namespace L05.CharacterSequence {
    class Program {
        static void Main(string[] args) {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++) {
                Console.WriteLine(input[i]);
            }
        }
    }
}
