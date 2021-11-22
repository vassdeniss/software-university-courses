using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ME04.SantasSecretHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex match = new Regex(@"@(?<name>[A-Za-z]+)[^@\-!:>]*!(?<behaviour>[NG])!");
            int decryptionKey = int.Parse(Console.ReadLine());

            string input;
            StringBuilder goodChildren = new StringBuilder();
            while ((input = Console.ReadLine()) != "end")
            {
                string decrypted = DecryptString(input, decryptionKey);
                Match kid = match.Match(decrypted);
                if (kid.Groups["behaviour"].Value.ToString() == "G")
                {
                    goodChildren.AppendLine(kid.Groups["name"].Value);
                }
            }

            Console.WriteLine(goodChildren);
        }

        static string DecryptString(string s, int key)
        {
            StringBuilder decryptedString = new StringBuilder();
            foreach (char c in s)
            {
                decryptedString.Append((char)(c - key));
            }
            return decryptedString.ToString();
        }
    }
}
