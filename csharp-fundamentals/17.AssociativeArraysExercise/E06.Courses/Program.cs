using System;
using System.Collections.Generic;
using System.Linq;

namespace E06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courseDictionary = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" : ");
            while (input[0] != "end")
            {
                string courseName = input[0];
                string studentName = input[1];

                if (courseDictionary.ContainsKey(courseName))
                    courseDictionary[courseName].Add(studentName);
                else
                    courseDictionary.Add(courseName, new List<string>() { studentName });

                input = Console.ReadLine().Split(" : ");
            }

            foreach (KeyValuePair<string, List<string>> pair in courseDictionary
                .OrderByDescending(list => list.Value.Count))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.Count}");
                foreach (string student in pair.Value.OrderBy(student => student))
                    Console.WriteLine($"-- {student}");
            }
        }
    }
}
