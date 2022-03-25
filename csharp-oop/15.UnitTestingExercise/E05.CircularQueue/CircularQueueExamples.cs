using System;

namespace E05.CircularQueue
{
    class CircularQueueExamples
    {
        static void Main()
        {
            Console.WriteLine("CircularQueue<T> Examples");
            Console.WriteLine("=========================");
            Console.WriteLine();

            CircularQueue<int> queue = new CircularQueue<int>();
            Console.WriteLine(queue);
            Console.WriteLine();

            queue.Enqueue(1);
            Console.WriteLine(queue);
            Console.WriteLine();

            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            Console.WriteLine(queue);
            Console.WriteLine();

            int first = queue.Dequeue();
            Console.WriteLine($"First = {first}");
            Console.WriteLine(queue);
            Console.WriteLine();

            queue.Enqueue(-7);
            queue.Enqueue(-8);
            queue.Enqueue(-9);
            Console.WriteLine(queue);
            Console.WriteLine($"Count = {queue.Count}. Capacity = {queue.Capacity}");
            Console.WriteLine($"StartIndex = {queue.StartIndex}. EndIndex = {queue.EndIndex}");
            Console.WriteLine();

            first = queue.Dequeue();
            Console.WriteLine("First = {0}", first);
            Console.WriteLine(queue);
            Console.WriteLine();

            queue.Enqueue(-10);
            Console.WriteLine("Count = {0}", queue.Count);
            Console.WriteLine(queue);
            Console.WriteLine();

            first = queue.Dequeue();
            Console.WriteLine("First = {0}", first);
            Console.WriteLine(queue);
            Console.WriteLine($"Count = {queue.Count}. Capacity = {queue.Capacity}");
            Console.WriteLine($"StartIndex = {queue.StartIndex}. EndIndex = {queue.EndIndex}");
            Console.WriteLine();
        }
    }
}
