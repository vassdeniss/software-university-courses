using System;

namespace E01.OldBooks {
    class Program {
        static void Main(string[] args) {
            string requiredBook = Console.ReadLine();
            string currentBook = Console.ReadLine();
            int checkedBooks = 0;

            while (currentBook != requiredBook) {
                if (currentBook == "No More Books") {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {checkedBooks} books.");
                    return;
                }
                checkedBooks++;
                currentBook = Console.ReadLine();
            }

            Console.WriteLine($"You checked {checkedBooks} books and found it.");
        }
    }
}
