using System;
using System.Text;

namespace E04.CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            foreach (char c in text)
            {
                char letter = c;
                sb.Append(letter += (char)3);
            }

            Console.WriteLine(sb);
        }
    }
}
