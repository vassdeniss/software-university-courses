using System;
using System.Collections.Generic;
using System.Text;

namespace E09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> words = new Stack<string>();
            words.Push(string.Empty);
            StringBuilder sb = new StringBuilder();

            int operations = int.Parse(Console.ReadLine());
            for (int i = 0; i < operations; i++)
            {
                string[] commands = Console.ReadLine().Split();
                if (commands[0] == "1")
                {
                    string append = commands[1];
                    sb.Append(append);
                    words.Push(sb.ToString());
                }
                else if (commands[0] == "2")
                {
                    int erase = int.Parse(commands[1]);
                    sb.Remove(sb.Length - erase, erase);
                    words.Push(sb.ToString());
                }
                else if (commands[0] == "3")
                {
                    int index = int.Parse(commands[1]);
                    Console.WriteLine(sb[index - 1]);
                }
                else
                {
                    words.Pop();
                    sb.Clear();
                    sb.Append(words.Peek());
                }
            }
        }
    }
}
