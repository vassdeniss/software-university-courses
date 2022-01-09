using System;
using System.Collections.Generic;

namespace L03.WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> wordSynonyms = new Dictionary<string, List<string>>();

            int wordQty = int.Parse(Console.ReadLine());
            for (int i = 0; i < wordQty; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (wordSynonyms.ContainsKey(word))
                {
                    wordSynonyms[word].Add(synonym);
                }
                else
                {
                    wordSynonyms.Add(word, new List<string>());
                    wordSynonyms[word].Add(synonym);
                }
            }

            foreach (KeyValuePair<string, List<string>> word in wordSynonyms)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}
