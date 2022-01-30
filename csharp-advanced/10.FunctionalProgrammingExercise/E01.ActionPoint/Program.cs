using System;

namespace E01.ActionPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = x => Console.WriteLine(string.Join(Environment.NewLine, x));
            string[] names = Console.ReadLine().Split(); 
            print(names);
        }
    }
}
