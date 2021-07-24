using System;

namespace YardGreening {
    class Program {
        static void Main(string[] args) {
            double squareMeters = double.Parse(Console.ReadLine());
            double price = squareMeters * 7.61;
            double discount = price * 18 / 100;
            double finalPrice = price - discount;
            Console.WriteLine($"The final price is: {finalPrice} lv.\nThe discount is: {discount} lv.");
        }
    }
}
