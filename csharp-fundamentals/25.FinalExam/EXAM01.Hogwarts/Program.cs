using System;

namespace EXAM01.Hogwarts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();

            string input = Console.ReadLine();
            while (input != "Abracadabra")
            {
                string[] cmd = input.Split();
                
                if (cmd[0] == "Abjuration")
                {
                    spell = spell.ToUpper();
                    Console.WriteLine(spell);
                }
                else if (cmd[0] == "Necromancy")
                {
                    spell = spell.ToLower();
                    Console.WriteLine(spell);
                }
                else if (cmd[0] == "Illusion")
                {
                    if (int.Parse(cmd[1]) < 0 || int.Parse(cmd[1]) >= spell.Length)
                    {
                        Console.WriteLine("The spell was too weak.");
                        input = Console.ReadLine();
                        continue;
                    }

                    char[] arr = spell.ToCharArray();
                    arr[int.Parse(cmd[1])] = char.Parse(cmd[2]);
                    spell = new string(arr);
                    Console.WriteLine("Done!");
                }
                else if (cmd[0] == "Divination")
                {
                    if (spell.Contains(cmd[1]))
                    {
                        spell = spell.Replace(cmd[1], cmd[2]);
                        Console.WriteLine(spell);
                    }
                }
                else if (cmd[0] == "Alteration")
                {
                    if (spell.Contains(cmd[1]))
                    {
                        int index = spell.IndexOf(cmd[1]);
                        spell = spell.Remove(index, cmd[1].Length);
                        Console.WriteLine(spell);
                    }
                }
                else Console.WriteLine("The spell did not work!");

                input = Console.ReadLine();
            }
        }
    }
}
