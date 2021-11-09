using System;
using System.Collections.Generic;
using System.Linq;

namespace E07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> gradeDictionary = new Dictionary<string, List<double>>();
            for (int i = 0; i < num; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (gradeDictionary.ContainsKey(name))
                    gradeDictionary[name].Add(grade);
                else
                    gradeDictionary.Add(name, new List<double>() { grade });
            }

            Dictionary<string, double> bestGradeDictionary = PopulateBestGradeDictionary(gradeDictionary);

            foreach (KeyValuePair<string, double> pair in bestGradeDictionary.OrderByDescending(student => student.Value))
                Console.WriteLine($"{pair.Key} -> {pair.Value:f2}");
        }

        static Dictionary<string, double> PopulateBestGradeDictionary(Dictionary<string, List<double>> fromDic)
        {
            Dictionary<string, double> toDic = new Dictionary<string, double>();
            foreach (KeyValuePair<string, List<double>> pair in from pair in fromDic
                                                                where pair.Value.Average() >= 4.50
                                                                select pair)
            {
                toDic.Add(pair.Key, pair.Value.Average());
            }
            return toDic;
        }
    }
}
