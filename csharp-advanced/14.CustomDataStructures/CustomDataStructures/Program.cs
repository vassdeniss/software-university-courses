using System;

namespace CustomDataStructures
{
    public class Program
    {
        static void Main()
        {
            CustomList<int> customList = new CustomList<int>();
            TestList(customList);
            // Count of elements in list: 5
            // Index 0 is 1
            // Elements in list: 1 2 3 4 5
            // Elements in list as array: 1 2 3 4 5
            // Does 5 exist ?: True
            // List count after clear?: 0

            CustomStack<int> customStack = new CustomStack<int>();
            TestStack(customStack);
            // Count of elements in stack: 5
            // Elements in stack: 1 2 3 4 5
            // Elements in stack as array: 1 2 3 4 5
            // Does 5 exist ?: True
            // Peek elemnt?: 5
            // Stack count after clear?: 0

            CustomQueue<int> customQueue = new CustomQueue<int>();
            TestQueue(customQueue);
            // Count of elements in queue: 5
            // Elements in queue: 1 2 3 4 5
            // Elements in queue as array: 1 2 3 4 5
            // Does 5 exist ?: True
            // Peek elemnt?: 1
            // Stack count after clear?: 0
        }

        private static void TestList(CustomList<int> list)
        {
            list.Add(1);
            list.Add(3);
            list.Add(2);
            list.Add(5);
            list.Add(5);
            list.Swap(1, 2);
            list.RemoveAt(3);
            list.Insert(3, 4);

            Console.WriteLine($"Count of elements in list: {list.Count}");
            Console.WriteLine($"Index 0 is {list[0]}");
            Console.Write("Elements in list: ");
            list.ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();
            Console.WriteLine($"Elements in list as array: {string.Join(" ", list.ToArray())}");
            Console.WriteLine($"Does 5 exist?: {list.Contains(5)}");
            list.Clear();
            Console.WriteLine($"List count after clear?: {list.Count}");

            Console.WriteLine();
        }

        private static void TestStack(CustomStack<int> stack)
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(10);
            stack.Pop();

            Console.WriteLine($"Count of elements in stack: {stack.Count}");
            Console.Write("Elements in stack: ");
            stack.ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();
            Console.WriteLine($"Elements in stack as array: {string.Join(" ", stack.ToArray())}");
            Console.WriteLine($"Does 5 exist?: {stack.Contains(5)}");
            Console.WriteLine($"Peek elemnt?: {stack.Peek()}");
            stack.Clear();
            Console.WriteLine($"Stack count after clear?: {stack.Count}");

            Console.WriteLine();
        }

        private static void TestQueue(CustomQueue<int> queue)
        {
            queue.Enqueue(10);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Dequeue();

            Console.WriteLine($"Count of elements in queue: {queue.Count}");
            Console.Write("Elements in queue: ");
            queue.ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();
            Console.WriteLine($"Elements in queue as array: {string.Join(" ", queue.ToArray())}");
            Console.WriteLine($"Does 5 exist?: {queue.Contains(5)}");
            Console.WriteLine($"Peek elemnt?: {queue.Peek()}");
            queue.Clear();
            Console.WriteLine($"Stack count after clear?: {queue.Count}");

            Console.WriteLine();
        }
    }
}
