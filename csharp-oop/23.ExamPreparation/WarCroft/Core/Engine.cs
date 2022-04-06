using System;
using System.Linq;

using WarCroft.Core.IO.Contracts;

namespace WarCroft.Core
{
    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly WarController warController;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

            warController = new WarController();
        }

        public void Run()
        {
            string command = reader.ReadLine();
            while (command != "END")
            {
                try
                {
                    ReadCommand(command);
                }
                catch (ArgumentException e)
                {
                    writer.WriteLine($"Parameter Error: {e.Message}");
                }
                catch (InvalidOperationException e)
                {
                    writer.WriteLine($"Invalid Operation: {e.Message}");
                }

                command = reader.ReadLine();
            }

            writer.WriteLine("Final stats:");
            writer.WriteLine(warController.GetStats());
        }

        private void ReadCommand(string command)
        {
            string[] commandArgs = command.Split(' ');
            string commandName = commandArgs[0];

            string[] args = commandArgs.Skip(1).ToArray();
            string output = string.Empty;
            switch (commandName)
            {
                case "JoinParty":
                    output = warController.JoinParty(args);
                    break;
                case "AddItemToPool":
                    output = warController.AddItemToPool(args);
                    break;
                case "PickUpItem":
                    output = warController.PickUpItem(args);
                    break;
                case "UseItem":
                    output = warController.UseItem(args);
                    break;
                case "GetStats":
                    output = warController.GetStats();
                    break;
                case "Attack":
                    output = warController.Attack(args);
                    break;
                case "Heal":
                    output = warController.Heal(args);
                    break;
            }

            if (output != string.Empty)
            {
                writer.WriteLine(output);
            }
        }
    }
}
