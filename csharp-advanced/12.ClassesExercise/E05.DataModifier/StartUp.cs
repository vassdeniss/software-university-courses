using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDAte = Console.ReadLine();

            int diff = DateModifier.DiffBetweenDates(firstDate, secondDAte);
            Console.WriteLine(diff);
        }
    }
}
