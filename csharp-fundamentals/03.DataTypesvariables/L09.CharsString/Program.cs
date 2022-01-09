using System;

namespace L09.CharsString
{
    class Program
    {
        static void Main(string[] args)
        {
            char one = char.Parse(Console.ReadLine()); 
            char two = char.Parse(Console.ReadLine()); 
            char three = char.Parse(Console.ReadLine());
            Console.WriteLine($"{one}{two}{three}");
        }
    }
}
