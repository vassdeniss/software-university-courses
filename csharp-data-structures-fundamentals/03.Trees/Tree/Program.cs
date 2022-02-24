namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Tree<int> tree =
                new Tree<int>(7,
                    new Tree<int>(19,
                        new Tree<int>(1),
                        new Tree<int>(12),
                        new Tree<int>(31)),
                    new Tree<int>(21),
                    new Tree<int>(14,
                        new Tree<int>(23),
                        new Tree<int>(6)));
            tree.PrettyPrintTree(tree, string.Empty);

            //Console.WriteLine($"Breadth-First Search: {string.Join(", ", tree.OrderBfs())}");
            //Console.WriteLine($"Depth-First Search: {string.Join(", ", tree.OrderDfs())}");

            Console.WriteLine();
            tree.RemoveNode(-10);
            tree.RemoveNode(12);
            tree.RemoveNode(31);

            tree.PrettyPrintTree(tree, string.Empty);

            Tree<string> tree2 =
                new Tree<string>("seven",
                    new Tree<string>("nineteen",
                        new Tree<string>("one"),
                        new Tree<string>("twelve"),
                        new Tree<string>("thirty-one")),
                    new Tree<string>("twenty-one"),
                    new Tree<string>("fourteen",
                        new Tree<string>("twenty-three"),
                        new Tree<string>("six")));
            tree2.PrettyPrintTree(tree2, string.Empty);

            //Console.WriteLine($"Breadth-First Search: {string.Join(", ", tree.OrderBfs())}");
            //Console.WriteLine($"Depth-First Search: {string.Join(", ", tree.OrderDfs())}");

        }
    }
}
