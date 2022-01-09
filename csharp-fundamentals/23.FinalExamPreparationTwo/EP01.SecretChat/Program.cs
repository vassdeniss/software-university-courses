using System;
using System.Linq;

namespace EP01.SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string message = input;
            while (input != "Reveal")
            {
                string[] cmd = input.Split(":|:");

                if (cmd[0] == "InsertSpace")
                {
                    message = message.Insert(int.Parse(cmd[1]), " ");
                    Console.WriteLine(message);
                }
                else if (cmd[0] == "Reverse")
                {
                    string substring = cmd[1];
                    int start = message.IndexOf(substring);
                    if (message.Contains(substring))
                    {
                        message = message.Remove(start, substring.Length);
                        message += new string(substring.ToCharArray().Reverse().ToArray());
                        Console.WriteLine(message);
                    }
                    else Console.WriteLine("error");
                }
                else if (cmd[0] == "ChangeAll")
                {
                    message = message.Replace(cmd[1], cmd[2]);
                    Console.WriteLine(message);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
