using Operations.Contracts;
using Operations.Models;
using System;

namespace Operations.Core
{
    public class Engine : IRunnable
    {
        public void Run()
        {
            MathOperations mo = new MathOperations();
            Console.WriteLine(mo.Add(2, 3));
            Console.WriteLine(mo.Add(2.2, 3.3, 5.5));
            Console.WriteLine(mo.Add(2.2m, 3.3m, 4.4m));
        }
    }
}
