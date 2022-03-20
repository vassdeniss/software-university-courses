using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands
{
    internal class AgeCommand : ICommand
    {
        public string Execute(string[] args)
        {
            int age = int.Parse(args[1]);
            if (age < 18) return $"{args[0]} is not an adult";
            else return $"{args[0]} is an adult";
        }
    }
}
