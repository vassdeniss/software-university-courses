using System;

namespace L04.BitDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int postion = int.Parse(Console.ReadLine());

            int mask = ~(1 << postion);
            // Take a binary 1 and shift the one to the
            // desired position and flip it into a 0 so the
            // bitwise AND works properly
            Console.WriteLine(num & mask);
            // Every 1 and every 0 in the original number
            // will remain the samebut the number in the position will
            // get compared with a 0 and that wil always turn it
            // into a zero
        }
    }
}
