using System;
using System.Collections.Generic;
using System.Linq;

namespace O03.ThePianist
{
    class Composer
    {
        public Composer(string piece, string composerName, string key)
        {
            Piece = piece;
            ComposerName = composerName;
            Key = key;
        }

        public string Piece { get; set; }
        public string ComposerName { get; set; }
        public string Key { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Composer> composersList = new List<Composer>();

            int piecesQty = int.Parse(Console.ReadLine());
            for (int i = 0; i < piecesQty; i++)
            {
                string[] cmd = Console.ReadLine().Split('|');
                composersList.Add(new Composer(cmd[0], cmd[1], cmd[2]));
            }

            string input = Console.ReadLine();
            while (input != "Stop")
            {
                string[] cmd = input.Split('|');
                string piece = cmd[1];
                bool isInList = composersList.Contains(composersList.Find(x => x.Piece == piece));

                if (cmd[0] == "Add")
                {
                    string composer = cmd[2];
                    string key = cmd[3];

                    if (isInList)
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        composersList.Add(new Composer(piece, composer, key));
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (cmd[0] == "Remove")
                {
                    if (isInList)
                    {
                        composersList.Remove(composersList.Find(x => x.Piece == piece));
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                }
                else if (cmd[0] == "ChangeKey")
                {
                    string newKey = cmd[2];

                    if (isInList)
                    {
                        composersList.Find(x => x.Piece == piece).Key = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                }

                input = Console.ReadLine();
            }

            foreach (Composer composer in composersList.OrderBy(x => x.Piece).ThenBy(x => x.ComposerName))
                Console.WriteLine($"{composer.Piece} -> Composer: {composer.ComposerName}, Key: {composer.Key}");
        }
    }
}
