using E04.BorderControl.Contracts;
using E04.BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E04.BorderControl.Core
{
    public class Engine : IRunnable
    {
        private readonly IList<string> ids;

        public Engine()
        {
            ids = new List<string>();
        }

        public void Run()
        {
            RegisterResidentIDs();
            DetainFakeIDs();
        }

        private void DetainFakeIDs()
        {
            string fakeIdNo = Console.ReadLine();
            string[] fakeIds = ids.Where(x => x.EndsWith(fakeIdNo)).ToArray();
            foreach (string fakeId in fakeIds)
            {
                Console.WriteLine(fakeId);
            }
        }

        private void RegisterResidentIDs()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = input.Split();

                IResident resident;
                switch (data.Length)
                {
                    case 2:
                        resident = new Robot(data[0], data[1]);
                        break;
                    default:
                        resident = new Citizen(data[0], data[1], data[2]);
                        break;
                }

                ids.Add(resident.ID);
                input = Console.ReadLine();
            }
        }
    }
}
