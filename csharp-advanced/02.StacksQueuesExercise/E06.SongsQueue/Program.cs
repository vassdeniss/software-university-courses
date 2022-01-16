using System;
using System.Collections.Generic;
using System.Linq;

namespace E06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");

            Queue<string> songQueue = new Queue<string>(songs);
            while (songQueue.Count > 0)
            {
                string[] cmd = Console.ReadLine().Split();
                if (cmd[0] == "Play") songQueue.Dequeue();
                else if (cmd[0] == "Add")
                {
                    string song = string.Join(" ", cmd.Skip(1));
                    if (songQueue.Contains(song)) Console.WriteLine($"{song} is already contained!");
                    else songQueue.Enqueue(song);
                }
                else Console.WriteLine(string.Join(", ", songQueue));
            }

            Console.WriteLine("No more songs!");
            return;
        }
    }
}
