using System;

namespace E06.TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    for (int k = 0; k < num; k++)
                    {
                        char one = (char)('a' + i);
                        char two = (char)('a' + j);
                        char three = (char)('a' + k);

                        Console.WriteLine($"{one}{two}{three}");
                    }
                }
            }
        }
    }
}
