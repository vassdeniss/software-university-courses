using System;
using System.Collections.Generic;
using System.Linq;

namespace E11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrel = int.Parse(Console.ReadLine());
            int[] bulletsArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int value = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsArr);
            Queue<int> locks = new Queue<int>(locksArr);

            int totalBullets = 0;
            int cBarrel = barrel;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                int cBullet = bullets.Pop();
                totalBullets++;
                cBarrel--;
                int cLock = locks.Peek();

                if (cBullet <= cLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else Console.WriteLine("Ping!");

                if (bullets.Count > 0 && cBarrel == 0)
                {
                    Console.WriteLine("Reloading!");
                    cBarrel = barrel;
                }
            }
            
            if (locks.Count <= 0) 
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${value - (totalBullets * bulletPrice)}");
            else 
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}
