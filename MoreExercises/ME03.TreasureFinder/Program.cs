using System;
using System.Linq;
using System.Text;

namespace ME03.TreasureFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] decrypters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            while (input != "find")
            {
                Console.WriteLine(FindTreasure(DecryptMessage(input, decrypters)));
                input = Console.ReadLine();
            }
        }

        static string DecryptMessage(string encrypted, int[] decrypters)
        {
            StringBuilder sb = new StringBuilder();

            int iterator = 0;
            foreach (char c in encrypted)
            {
                sb.Append((char)(c - decrypters[iterator]));
                iterator++;
                if (iterator >= decrypters.Length) iterator = 0;
            }

            return sb.ToString();
        }

        static string FindTreasure(string decrypted)
        {
            int treasureStart = decrypted.IndexOf('&');
            int treasureEnd = decrypted.IndexOf('&', treasureStart + 1);
            int locationStart = decrypted.IndexOf('<');
            int locationEnd = decrypted.IndexOf('>');

            string treasure = decrypted[(treasureStart + 1)..treasureEnd];
            string location = decrypted[(locationStart + 1)..locationEnd];

            return $"Found {treasure} at {location}";
        }
    }
}
