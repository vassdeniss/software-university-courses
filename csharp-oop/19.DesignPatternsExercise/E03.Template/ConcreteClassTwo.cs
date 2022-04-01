using System;

namespace E03.Template
{
    public class ConcreteClassTwo : AbstractClass
    {
        protected override void RequiredOne()
        {
            Console.WriteLine("ConcreteClassTwo says: Implemented RequiredOne");
        }

        protected override void RequiredTwo()
        {
            Console.WriteLine("ConcreteClassTwo says: Implemented RequiredTwo");
        }

        protected override void HookOne()
        {
            Console.WriteLine("ConcreteClassTwo says: Overridden HookOne");
        }
    }
}
