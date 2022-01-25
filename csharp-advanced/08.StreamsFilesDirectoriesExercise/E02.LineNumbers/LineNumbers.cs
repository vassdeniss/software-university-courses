using System.IO;
using System.Linq;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";
            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string input, string output)
        {
            char[] marksArr = new char[] { '-', ',', '.', '!', '?', '\'' };
            string[] lines = File.ReadAllLines(input);
            string[] outputLines = new string[lines.Length];

            int idx = 0;
            foreach (string line in lines)
            {
                int chars = 0;
                int marks = 0;
                foreach (char c in line)
                {
                    if (char.IsLetter(c)) chars++;
                    if (marksArr.Contains(c)) marks++;
                }

                outputLines[idx] = $"Line {++idx}: {line} ({chars})({marks})";
            }

            File.WriteAllLines(output, outputLines);
        }
    }
}
