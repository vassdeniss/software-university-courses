using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter interpreter;

        public Engine(ICommandInterpreter interpreter) => this.interpreter = interpreter;

        public void Run()
        {
            while (true)
            {
                try
                {
                    string args = Console.ReadLine();
                    string result = interpreter.Read(args);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
