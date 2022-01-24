using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\words.txt";
            string textPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string word, string text, string output)
        {
            using StreamReader wordReader = new StreamReader(word);
            string[] words = wordReader.ReadToEnd().Split(" ");

            Dictionary<string, int> wordCounter = new Dictionary<string, int>();
            Regex pattern = new Regex(@"[A-z']+");

            using StreamReader textReader = new StreamReader(text);
            string line = textReader.ReadLine();
            while (line != null)
            {
                MatchCollection matches = pattern.Matches(line);
                foreach (Match match in matches)
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (match.Value.ToLower() == words[i])
                        {
                            if (!wordCounter.ContainsKey(words[i])) wordCounter.Add(words[i], 0);
                            wordCounter[words[i]]++;
                        }
                    }
                }

                line = textReader.ReadLine();
            }

            using StreamWriter writer = new StreamWriter(output);
            foreach (KeyValuePair<string, int> kvp in 
                wordCounter.OrderByDescending(x => x.Value))
            {
                writer.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
