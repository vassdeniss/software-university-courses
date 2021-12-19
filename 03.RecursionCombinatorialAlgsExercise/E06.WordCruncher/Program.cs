using System;
using System.Collections.Generic;

namespace E06.WordCruncher
{
    internal class Program
    {
        static string target;
        static Dictionary<int, List<string>> indexWords;
        static Dictionary<string, int> wordCount;
        static LinkedList<string> wordList;

        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(", ");
            target = Console.ReadLine();

            indexWords = new Dictionary<int, List<string>>();
            wordCount = new Dictionary<string, int>();
            wordList = new LinkedList<string>();

            FillCollections(words);
            GenSolutions(0);
        }

        private static void FillCollections(string[] words)
        {
            foreach (string word in words)
            {
                int ind = target.IndexOf(word);
                if (ind == -1) continue;

                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                    continue;
                }

                wordCount[word] = 1;
                while (ind != -1)
                {
                    if (!indexWords.ContainsKey(ind)) indexWords[ind] = new List<string>();
                    indexWords[ind].Add(word);
                    ind = target.IndexOf(word, ind + 1);
                }
            }
        }

        private static void GenSolutions(int ind)
        {
            if (ind == target.Length)
            {
                Console.WriteLine(string.Join(" ", wordList));
                return;
            }

            if (!indexWords.ContainsKey(ind)) return;

            foreach (string word in indexWords[ind])
            {
                if (wordCount[word] == 0) continue;

                wordCount[word]--;
                wordList.AddLast(word);

                GenSolutions(ind + word.Length);

                wordCount[word]++;
                wordList.RemoveLast();
            } 
        }
    }
}