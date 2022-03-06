using E07.MilitaryElite.Contracts;
using E07.MilitaryElite.Enums;
using E07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E07.MilitaryElite.Core
{
    public class Engine : IRunnable
    {
        private readonly List<ISoldier> soldiers;

        public Engine()
        {
            soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                try
                {
                    string[] tokens = input
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string result = RegisterSoldiers(tokens);
                    Console.WriteLine(result);
                }
                catch (ArgumentException) { }

                input = Console.ReadLine();
            }
        }

        private string RegisterSoldiers(string[] tokens)
        {
            string type = tokens[0];
            string id = tokens[1];
            string firstName = tokens[2];
            string lastName = tokens[3];

            ISoldier soldier = null;
            if (type == "Private")
            {
                decimal salary = decimal.Parse(tokens[4]);
                soldier = new Private(id, firstName, lastName, salary);
            }
            else if (type == "LieutenantGeneral")
            {
                List<IPrivate> list = new List<IPrivate>();

                string[] ids = tokens.Skip(5).ToArray();
                for (int i = 0; i < ids.Length; i++)
                {
                    ISoldier @private = soldiers.FirstOrDefault(x => x.ID == ids[i]);
                    if (@private != null) list.Add((IPrivate)@private);
                }

                decimal salary = decimal.Parse(tokens[4]);
                soldier = new LieutenantGeneral(id, firstName, lastName, salary, list);
            }
            else if (type == "Engineer")
            {
                bool isValidCorps = Enum.TryParse(tokens[5], out Corps corp);
                if (!isValidCorps) throw new ArgumentException();

                List<IRepair> list = new List<IRepair>();

                string[] repairs = tokens.Skip(6).ToArray();
                for (int i = 0; i < repairs.Length; i += 2)
                {
                    string name = repairs[i];
                    int hours = int.Parse(repairs[i + 1]);
                    list.Add(new Repair(name, hours));
                }

                decimal salary = decimal.Parse(tokens[4]);
                soldier = new Engineer(id, firstName, lastName, salary, corp, list);
            }
            else if (type == "Commando")
            {
                bool isValidCorps = Enum.TryParse(tokens[5], out Corps corp);
                if (!isValidCorps) throw new ArgumentException();

                List<IMission> list = new List<IMission>();

                string[] missions = tokens.Skip(6).ToArray();
                for (int i = 0; i < missions.Length; i += 2)
                {
                    string name = missions[i];
                    string state = missions[i + 1];

                    bool isValidState = Enum.TryParse(state, out State stateResult);
                    if (!isValidState) continue;

                    list.Add(new Mission(name, stateResult));
                }

                decimal salary = decimal.Parse(tokens[4]);
                soldier = new Commando(id, firstName, lastName, salary, corp, list);
            }
            else if (type == "Spy")
            {
                int number = int.Parse(tokens[4]);
                soldier = new Spy(id, firstName, lastName, number);
            }

            soldiers.Add(soldier);
            return soldier.ToString();
        }
    }
}
