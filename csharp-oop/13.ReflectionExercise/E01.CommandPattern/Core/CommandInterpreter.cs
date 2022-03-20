using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args.Split();

            string commandName = input[0];
            string[] value = input.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == $"{commandName}Command");

            if (type is null) throw new InvalidOperationException("Invalid command.");

            Type typeInterface = type.GetInterface("ICommand");

            if (typeInterface is null) throw new InvalidOperationException("Type does not inherit from ICommand.");
            
            ICommand command = Activator.CreateInstance(type) as ICommand;
            return command.Execute(value);
        }
    }
}
