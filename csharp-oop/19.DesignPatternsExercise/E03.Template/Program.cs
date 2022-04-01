using System;

namespace E03.Template
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Same client code can work with different subclasses:");
            ConcreteClassOne concreteClassOne = new ConcreteClassOne();
            concreteClassOne.TemplateMethod();

            Console.Write("\n");

            Console.WriteLine("Same client code can work with different subclasses:");
            ConcreteClassTwo concreteClassTwo = new ConcreteClassTwo();
            concreteClassTwo.TemplateMethod();
        }   
    }
}
