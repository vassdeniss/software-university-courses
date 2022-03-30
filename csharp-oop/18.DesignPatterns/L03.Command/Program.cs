using System;

namespace L03.Command
{
    internal class Program
    {
        static void Main()
        {
            ModifyPrice modifyPrice = new ModifyPrice();
            Product product = new Product("Nintendo Switch", 699.99m);

            modifyPrice.SetCommand(new ProductCommand(product, PriceAction.Decrease, 200));
            modifyPrice.Invoke();

            modifyPrice.SetCommand(new ProductCommand(product, PriceAction.Increase, 100));
            modifyPrice.Invoke();

            Console.WriteLine(product);
        }
    }
}
