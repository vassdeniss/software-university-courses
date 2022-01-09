using System;
using System.Collections.Generic;
using System.Linq;

namespace E08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyDictionary = new Dictionary<string, List<string>>();

            string[] data = Console.ReadLine().Split();
            while (data[0] != "End")
            {
                string companyName = data[0];
                string employeeId = data[2];

                if (companyDictionary.ContainsKey(companyName))
                {
                    if (!companyDictionary[companyName].Contains(employeeId))
                        companyDictionary[companyName].Add(employeeId);
                }
                else
                {
                    companyDictionary.Add(companyName, new List<string>() { employeeId });
                }

                data = Console.ReadLine().Split();
            }

            foreach (string companyName in companyDictionary.Keys.OrderBy(name => name))
            {
                Console.WriteLine(companyName);
                foreach (string employeeId in companyDictionary[companyName])
                    Console.WriteLine($"-- {employeeId}");
            }
        }
    }
}
