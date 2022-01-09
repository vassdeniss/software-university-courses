using System;
using System.Text;

namespace L05.DigitsLettersOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sbDigits = new StringBuilder();
            StringBuilder sbLetters = new StringBuilder();
            StringBuilder sbOther = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsDigit(c)) sbDigits.Append(c);
                else if (char.IsLetter(c)) sbLetters.Append(c);
                else sbOther.Append(c);
            }

            Console.WriteLine($"{sbDigits}\n{sbLetters}\n{sbOther}");
        }
    }
}
