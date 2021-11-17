using System;

namespace L02.Password {
    class Program {
        static void Main(string[] args) {
            string username = Console.ReadLine();
            string password = Console.ReadLine();
            string guessPassword = Console.ReadLine();

            while (guessPassword != password) {
                guessPassword = Console.ReadLine();
            }

            Console.WriteLine($"Welcome {username}!");
        }
    }
}
