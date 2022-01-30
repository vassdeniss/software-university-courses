using System;
using System.Collections.Generic;
using System.Linq;

namespace E10.PartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();
            List<string> invitations = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();
            while (input != "Print")
            {
                string[] cmd = input.Split(";");
                string command = cmd[0];
                string filter = cmd[1];
                string parameter = cmd[2];

                if (command == "Add filter") filters.Add(filter + parameter, GetPredicate(filter, parameter));
                else filters.Remove(filter + parameter);

                input = Console.ReadLine();
            }

            foreach (var (key, value) in filters) invitations.RemoveAll(value);

            Action<List<string>> print = x => Console.WriteLine(string.Join(" ", x)); 
            print(invitations);
        }

        private static Predicate<string> GetPredicate(string filter, string parameter)
        {
            if (filter == "Starts with") return x => x.StartsWith(parameter);
            if (filter == "Ends with") return x => x.EndsWith(parameter);
            if (filter == "Contains") return x => x.Contains(parameter);
            return x => x.Length == int.Parse(parameter);
        }
    }
}
