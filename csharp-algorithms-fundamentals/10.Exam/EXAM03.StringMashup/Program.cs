using System;
using System.Collections.Generic;

namespace EXAM03.StringMashup
{
    internal class Program
    {
        private static HashSet<string> Set;

        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Set = new HashSet<string>();
            Gen(str.ToCharArray(), 0);
            Set.Add(str);
            foreach (string s in Set) Console.WriteLine(s);
        }

        private static void Gen(char[] arr, int idx)
        {
            if (idx >= arr.Length)
            {
                Set.Add(new string(arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                if (!char.IsDigit(arr[idx]))
                {
                    if (i == 0) arr[idx] = char.ToUpper(arr[idx]);
                    else arr[idx] = char.ToLower(arr[idx]);
                }

                Gen(arr, idx + 1);
            }
        }
    }
}
