using System;

namespace E03.Template
{
    public class ConcreteClassOne : AbstractClass
    {
        protected override void RequiredOne()
        {
            Console.WriteLine("ConcreteClassOne says: Implemented RequiredOne");
        }

        protected override void RequiredTwo()
        {
            Console.WriteLine("ConcreteClassOne says: Implemented RequiredTwo");
        }
    }
}
