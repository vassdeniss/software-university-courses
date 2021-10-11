using System;

namespace E09.PalindromeIntegers
{
    class Program
    {
        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static void isPalindrome(string s)
        {
            string comparator = Reverse(s);
            if (s == comparator)
            {
                Console.WriteLine("true");
                return;
            }
            Console.WriteLine("false");
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                isPalindrome(input);
                input = Console.ReadLine();
            }
        }
    }
}
