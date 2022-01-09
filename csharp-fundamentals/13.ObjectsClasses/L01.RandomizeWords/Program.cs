using System;
using System.Collections.Generic;
using System.Linq;

namespace L01.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> inputList = input.Split().ToList();
            Random rnd = new Random();

            for (int i = 0; i < inputList.Count; i++)
            {
                int rndNum = rnd.Next(0, inputList.Count);
                string temp = inputList[i];
                inputList[i] = inputList[rndNum];
                inputList[rndNum] = temp;
            }

            foreach (string s in inputList)
                Console.WriteLine(s);
        }
    }
}
