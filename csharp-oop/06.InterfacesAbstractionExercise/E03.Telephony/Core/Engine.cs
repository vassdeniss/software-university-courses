using E03.Telephony.Contracts;
using E03.Telephony.Models;
using System;
using System.Collections.Generic;

namespace E03.Telephony.Core
{
    public class Engine : IRunnable
    {
        private Smartphone smartphone;
        private Stationary stationary;
        private IList<string> phoneNumbers;
        private IList<string> urls;

        public Engine()
        {
            smartphone = new Smartphone();
            stationary = new Stationary();
            phoneNumbers = new List<string>();
            urls = new List<string>();
        }

        public void Run()
        {
            phoneNumbers = Console.ReadLine().Split();
            urls = Console.ReadLine().Split();

            CallNumbers();
            BrowseWebsites();
        }

        private void CallNumbers()
        {
            foreach (string number in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(DeterminePhone(number));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void BrowseWebsites()
        {
            foreach (string url in urls)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private string DeterminePhone(string number)
        {
            return number.Length == 10 ? smartphone.Call(number) : stationary.Dial(number); 
        }
    }
}
