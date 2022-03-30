using System;

namespace L02.Facade
{
    internal class Program
    {
        static void Main()
        {
            SubsystemOne subsystemOne = new SubsystemOne();
            SubsystemTwo subsystemTwo = new SubsystemTwo();

            Facade facade = new Facade(subsystemOne, subsystemTwo);

            Console.WriteLine(facade.Operation());
        }
    }
}
