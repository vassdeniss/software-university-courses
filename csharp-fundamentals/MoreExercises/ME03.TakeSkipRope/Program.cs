using System;
using System.Collections.Generic;

namespace ME03.TakeSkipRope
{
    class Program
    {
        static string TakeSkip(List<char> charList, List<int> intList)
        {
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            for (int i = 0; i < intList.Count; i++)
            {
                if (i % 2 == 0) takeList.Add(intList[i]);
                else skipList.Add(intList[i]);
            }

            string result = string.Empty;
            int step = 0;
            for (int i = 0; i < charList.Count; i++)
            {
                if (step >= takeList.Count) break;

                int takeListMax = takeList[step];
                int skipListMax = skipList[step];

                for (int j = 0; j < takeListMax; j++)
                {
                    try
                    {
                        result += charList[i];
                        i++;
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }

                if (skipListMax <= 0) i--;
                if (skipListMax > 1) i += skipListMax - 1;
                step++;
            }

            return result;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> intList = new List<int>();
            List<char> charList = new List<char>();

            foreach (char c in input)
            {
                if (!char.IsDigit(c)) charList.Add(c);
                else if (char.IsDigit(c)) intList.Add((int)char.GetNumericValue(c));
            }

            Console.WriteLine(TakeSkip(charList, intList));
        }
    }
}
