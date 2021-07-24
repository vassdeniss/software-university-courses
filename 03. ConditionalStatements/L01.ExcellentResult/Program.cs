using System;

namespace L01.ExcellentResult {
    class Program {
        static void Main(string[] args) {
            double grade = double.Parse(Console.ReadLine()); 
            if (grade >= 5.50) { Console.WriteLine("Excellent!"); }
        }
    }
}
