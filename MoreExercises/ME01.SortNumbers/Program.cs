using System;

namespace ME01.SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine()); 
            int numTwo = int.Parse(Console.ReadLine()); 
            int numThree = int.Parse(Console.ReadLine());

            int[] numArray = { numOne, numTwo, numThree };
            Array.Sort(numArray);
            Array.Reverse(numArray);

            foreach (int i in numArray)
            {
                Console.WriteLine(i);
            }
        }
    }
}
