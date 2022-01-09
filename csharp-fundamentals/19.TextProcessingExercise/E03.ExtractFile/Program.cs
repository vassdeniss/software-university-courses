using System;

namespace E03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] path = Console.ReadLine().Split(@"\");
            string file = path[^1];
            Console.WriteLine($"File name: {file.Split('.')[0]}");
            Console.WriteLine($"File extension: {file.Split('.')[1]}");
        }
    }
}
