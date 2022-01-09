using System;
using System.Collections.Generic;
using System.Linq;

namespace L06.StoreBoxes
{
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    class Box
    {
        public Box() => Item = new Item();
        public long SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal BoxPrice { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] cmd = Console.ReadLine().Split();
            List<Box> boxList = new List<Box>();

            while (cmd[0] != "end")
            {
                long serialNumber = long.Parse(cmd[0]);
                string name = cmd[1];
                int itemQty = int.Parse(cmd[2]);
                decimal price = decimal.Parse(cmd[3]);
                decimal boxPrice = price * itemQty;

                Item newItem = new Item()
                {
                    Name = name,
                    Price = price
                };

                Box newBox = new Box()
                {
                    SerialNumber = serialNumber,
                    Item = newItem,
                    ItemQuantity = itemQty,
                    BoxPrice = boxPrice
                };

                boxList.Add(newBox);
                cmd = Console.ReadLine().Split();
            }

            foreach (Box box in boxList.OrderByDescending(bp => bp.BoxPrice))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.BoxPrice:f2}");
            }
        }
    }
}
