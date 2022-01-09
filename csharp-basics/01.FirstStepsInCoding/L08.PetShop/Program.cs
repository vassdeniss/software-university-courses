using System;

namespace PetShop {
    class Program {
        static void Main(string[] args) {
            int dogCount = int.Parse(Console.ReadLine());
            int otherAnimalCount = int.Parse(Console.ReadLine());
            double totalPrice = dogCount * 2.50 + otherAnimalCount * 4.00;
            Console.WriteLine($"{totalPrice} lv.");
        }
    }
}
