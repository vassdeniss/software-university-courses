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
            string result = "BALANCED";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    if (openingBracket) result = "UNBALANCED";
                    openingBracket = true;
                    closingBracket = false;
                }
                else if (input == ")")
                {
                    if (!openingBracket) result = "UNBALANCED";
                    if (closingBracket) result = "UNBALANCED";
                    openingBracket = false;
                    closingBracket = true;
                }
            }

            if (openingBracket) result = "UNBALANCED";
            Console.WriteLine(result);
        }
    }
}
