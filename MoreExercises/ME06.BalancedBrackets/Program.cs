using System;

namespace ME06.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool closingBracket = false;
            bool openingBracket = false;
            bool balanced = true;

            for (int i = 0; i < n; i++)
            {
                if (openingBracket && closingBracket)
                {
                    openingBracket = false;
                    closingBracket = false;
                }

                string input = Console.ReadLine();

                if (input == "(")
                {
                    if (openingBracket) balanced = false;
                    openingBracket = true;
                }
                else if (input == ")")
                {
                    if (!openingBracket) balanced = false;
                    closingBracket = true;
                }
            }

            if (balanced)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
