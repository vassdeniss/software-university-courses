using System;
using System.Collections.Generic;
using System.Linq;

namespace L02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();
            int qty = int.Parse(Console.ReadLine());
            for (int i = 0; i < qty; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                decimal grade = decimal.Parse(data[1]);

                if (students.ContainsKey(name)) students[name].Add(grade);
                else students.Add(name, new List<decimal>() { grade });
            }

            foreach (KeyValuePair<string, List<decimal>> kvp in students)
            {
                Console.Write($"{kvp.Key} -> ");
                foreach (double grade in kvp.Value) Console.Write($"{grade:f2} ");
                Console.Write($"(avg: {kvp.Value.Average():f2})\n");
            }
        }
    }
}
