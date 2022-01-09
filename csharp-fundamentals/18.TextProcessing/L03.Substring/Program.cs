using System;

namespace L03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string remove = Console.ReadLine();
            string word = Console.ReadLine();

            int removeIndex = word.IndexOf(remove);
            while (removeIndex > -1)
            {
                word = word.Remove(removeIndex, remove.Length);
                removeIndex = word.IndexOf(remove);
            }

            Console.WriteLine(word);
        }
    }
}
