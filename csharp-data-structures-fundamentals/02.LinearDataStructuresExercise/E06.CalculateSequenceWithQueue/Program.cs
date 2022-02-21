using System;
using System.Collections.Generic;

namespace E06.CalculateSequenceWithQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(n);
            list.Add(n);

            int counter = 0;
            for (int i = 2; i <= 50; i++)
            {
                switch (++counter)
                {
                    case 1: 
                        queue.Enqueue(queue.Peek() + 1); 
                        list.Add(queue.Peek() + 1); 
                        break;
                    case 2: 
                        queue.Enqueue(2 * queue.Peek() + 1); 
                        list.Add(2 * queue.Peek() + 1); 
                        break;
                    case 3: 
                        queue.Enqueue(queue.Peek() + 2); 
                        list.Add(queue.Peek() + 2); 
                        break;
                    default: 
                        counter = 0; 
                        queue.Dequeue(); 
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
