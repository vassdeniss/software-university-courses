using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private readonly List<IProduct> products;

        public ProductStock()
        {
            products = new List<IProduct>();
        }

        public IProduct this[int index] 
        { 
            get
            {
                CheckRange(index, 0, Count - 1);
                return products[index];
            }
            set
            {
                CheckRange(index, 0, Count - 1);
                products[index] = value;
            }
        }

        public int Count => products.Count;

        public void Add(IProduct product)
        {
            CheckProduct(product);
            products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            foreach (IProduct currProduct in products)
            {
                if (currProduct.Equals(product))
                {
                    return true;
                }
            }

            return false;
        }

        public IProduct Find(int index)
        {
            if (CheckRange(index))
            {
                return products[index];
            }

            throw new InvalidOperationException($"The index \"{index}\" does not exist!");
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return products.Where(x => x.Price == price).ToList();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return products.Where(x => x.Quantity == quantity).ToList();
        }

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
        {
            List<IProduct> list = new List<IProduct>();

            foreach (IProduct product in products)
            {
                if (product.Price >= lo && product.Price <= hi)
                {
                    list.Add(product);
                }
            }

            return list;
        }

        public IProduct FindByLabel(string label)
        {
            IProduct product = products.FirstOrDefault(x => x.Label == label);

            return product == null 
                ? throw new ArgumentException("Product with this label does not exist!")
                : product;
        }

        public IProduct FindMostExpensiveProduct()
        {
            if (products.Count == 0) throw new InvalidOperationException("Collection is empty!");
            return products.OrderByDescending(x => x.Price).First();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (IProduct product in products)
            {
                yield return product;
            }
        }

        public bool Remove(IProduct product)
        {
            return products.Remove(product);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void CheckProduct(IProduct product)
        {
            if (string.IsNullOrWhiteSpace(product.Label))
            {
                throw new InvalidOperationException("Label cannot be empty!");
            }

            if (product.Price <= 0)
            {
                throw new InvalidOperationException("Price cannot be lower or equal to zero!");
            }

            if (product.Quantity < 0)
            {
                throw new InvalidOperationException("Quantity cannot be lower than zero!");
            }
        }

        private void CheckRange(int index, int minValue, int maxValue)
        {
            if ((index < minValue) || (index > maxValue))
            {
                throw new ArgumentOutOfRangeException($"Parameter should be in the range [{minValue}...{maxValue}]");
            }
        }

        private bool CheckRange(int idx)
        {
            if ((idx < 0) || (idx > Count - 1))
            {
                return false;
            }

            return true;
        }
    }
}
