using System;
using System.Linq;

namespace E07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Action<string[]> print = x => Console.WriteLine(string.Join(Environment.NewLine, x));
            Predicate<string> isCorrectLength = x => x.Length <= length;

            string[] names = Console.ReadLine()
                .Split().Where(x => isCorrectLength(x)).ToArray();
            print(names);
        }
    }
}
