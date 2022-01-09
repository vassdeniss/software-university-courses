using System;
using System.Collections.Generic;

namespace L04.ListProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int productQuantity = int.Parse(Console.ReadLine());
            List<string> productList = new List<string>();

            for (int i = 0; i < productQuantity; i++)
                productList.Add(Console.ReadLine());

            productList.Sort();

            for (int i = 0; i < productList.Count; i++)
                Console.WriteLine($"{i + 1}.{productList[i]}");
        }
    }
}
