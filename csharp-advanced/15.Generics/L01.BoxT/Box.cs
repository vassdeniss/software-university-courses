using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> stack;

        public Box()
        {
            stack = new Stack<T>();
        }

        public int Count => stack.Count;

        public void Add(T element)
        {
            stack.Push(element);
        }

        public T Remove()
        {
            return stack.Pop();
        }
    }
}
