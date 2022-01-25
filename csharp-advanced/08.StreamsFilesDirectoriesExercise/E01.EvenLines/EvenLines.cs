using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EvenLines
{
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string input)
        {
            char[] replaceChars = new char[] { '-', ',', '.', '!', '?' };

            StringBuilder sb = new StringBuilder();
            using StreamReader reader = new StreamReader(input);
            
            int idx = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                if (idx++ % 2 == 0)
                {
                    string reversedLine = ReverseString(line);
                    foreach (char c in replaceChars) 
                        reversedLine = reversedLine.Replace(c, '@');

                    sb.AppendLine(reversedLine);
                }

                line = reader.ReadLine();
            }

            return sb.ToString();
        }

        public static string ReverseString(string s)
        {
            Stack<string> stack = new Stack<string>(s.Split());
            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0) sb.Append($"{stack.Pop()} ");

            return sb.ToString();
        }
    }
}
