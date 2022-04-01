using System;

namespace E03.Template
{
    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            BaseOne();
            RequiredOne();
            BaseTwo();
            HookOne();
            RequiredTwo();
            BaseThree();
            HookTwo ();
        }

        protected void BaseOne()
        {
            Console.WriteLine("AbstractClass says: I am doing the bulk of the work");
        }

        protected void BaseTwo()
        {
            Console.WriteLine("AbstractClass says: But I let subclasses override some operations");
        }

        protected void BaseThree()
        {
            Console.WriteLine("AbstractClass says: But I am doing the bulk of the work anyway");
        }

        protected abstract void RequiredOne();

        protected abstract void RequiredTwo();

        protected virtual void HookOne() { }

        protected virtual void HookTwo() { }
    }
}
