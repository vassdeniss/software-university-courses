using System;
using System.Collections.Generic;
using System.Linq;

namespace E05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();
            int rackLimit = int.Parse(Console.ReadLine());

            int sum = 0;
            int racks = 1;
            Stack<int> clothingStack = new Stack<int>(clothes);
            while (clothingStack.Count > 0)
            {
                int currClothing = clothingStack.Peek();

                if (sum + currClothing == rackLimit)
                {
                    clothingStack.Pop();
                    if (clothingStack.Count != 0) racks++;
                    sum = 0;
                }
                else if (sum + currClothing > rackLimit)
                {
                    racks++;
                    sum = 0;
                    sum += clothingStack.Pop();
                }
                else sum += clothingStack.Pop();
            }

            Console.WriteLine(racks);
        }
    }
}
