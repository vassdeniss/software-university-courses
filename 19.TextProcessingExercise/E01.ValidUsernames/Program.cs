using System;
using System.Linq;

namespace E01.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            foreach (string s in usernames)
            {
                if (ValidUsername(s))
                {
                    Console.WriteLine(s);
                }
            }
        }

        static bool ValidUsername(string s)
        {
            int stringLength = s.Length;
            char[] allowedSymbols = new char[] { '-', '_' };

            bool validLength = stringLength >= 3 && stringLength <= 16;
            bool validChars = true;

            foreach (char c in s)
            {
                if (!char.IsLetterOrDigit(c) && !allowedSymbols.Contains(c))
                {
                    validChars = false;
                    break;
                }
            }

            if (validLength && validChars) return true;
            else return false;
        }
    }
}
