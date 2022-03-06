using E08.CollectionHierarchy.Contracts;
using E08.CollectionHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E08.CollectionHierarchy.Core
{
    public class Engine : IRunnable
    {
        private readonly AddCollection addCollection;
        private readonly AddRemoveCollection addRemoveCollection;
        private readonly MyList myList;
        private Dictionary<string, string> output = new Dictionary<string, string>();

        public Engine()
        {
            addCollection = new AddCollection();
            addRemoveCollection = new AddRemoveCollection();
            myList = new MyList();
            output = new Dictionary<string, string>()
            {
                { "addCollection", string.Empty },
                { "addRemoveCollection", string.Empty },
                { "myList", string.Empty },
            };
        }

        public void Run()
        {
            string[] items = Console.ReadLine().Split();
            foreach (string item in items)
            {
                output["addCollection"] += addCollection.Add(item) + " ";
                output["addRemoveCollection"] += addRemoveCollection.Add(item) + " ";
                output["myList"] += myList.Add(item) + " ";
            }

            foreach (KeyValuePair<string, string> kvp in output)
            {
                Console.WriteLine(kvp.Value);
            }

            output["addRemoveCollection"] = string.Empty;
            output["myList"] = string.Empty;

            int remove = int.Parse(Console.ReadLine());
            for (int i = 0; i < remove; i++)
            {
                output["addRemoveCollection"] += addRemoveCollection.Remove() + " ";
                output["myList"] += myList.Remove() + " ";
            }

            foreach (KeyValuePair<string, string> kvp in output.Skip(1))
            {
                Console.WriteLine(kvp.Value);
            }
        }
    }
}
