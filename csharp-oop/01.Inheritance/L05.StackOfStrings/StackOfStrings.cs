using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return Count <= 0;
        }

        public void AddRange(Stack<string> range)
        {
            foreach (string item in range)
            {
                Push(item);
            }
        }
    }
}
