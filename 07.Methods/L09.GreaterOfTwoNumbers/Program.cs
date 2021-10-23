using System;

namespace L09.GreaterOfTwoNumbers
{
    class Program
    {
        static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }
        static char GetMax(char a, char b)
        {
            int biggerLetter = Math.Max(a, b);
            return (char)biggerLetter;
        }
        static string GetMax(string a, string b)
        {
            if (a.CompareTo(b) > 0) { return a; }
            else { return b; }
        }

        static void Main(string[] args)
        {
            string varType = Console.ReadLine();
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            switch(varType)
            {
                case "int":
                    Console.WriteLine(GetMax(int.Parse(a), int.Parse(b)));
                    break;
                case "char":
                    Console.WriteLine(GetMax(char.Parse(a), char.Parse(b)));
                    break;
                default:
                    Console.WriteLine(GetMax(a, b));
                    break;
            }
        }
    }
}
