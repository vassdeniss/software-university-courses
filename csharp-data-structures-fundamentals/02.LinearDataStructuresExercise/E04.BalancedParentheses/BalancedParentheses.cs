namespace E04.BalancedParentheses
{
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char bracket in parentheses)
            {
                if (bracket == '(' || bracket == '{' || bracket == '[') stack.Push(bracket);

                if (stack.Count == 0) return false;

                char compare = stack.Peek();
                if (compare == '(' && bracket == ')'
                    || compare == '{' && bracket == '}'
                    || compare == '[' && bracket == ']')
                {
                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }
    }
}
