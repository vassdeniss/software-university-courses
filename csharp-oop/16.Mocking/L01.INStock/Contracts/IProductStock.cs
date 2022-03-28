using System.Collections.Generic;

namespace INStock.Contracts
{
    public interface IProductStock : IEnumerable<IProduct>
    {
        int Count { get; }

        IProduct this[int index] { get; set; }

        bool Contains(IProduct product);

        void Add(IProduct product);

        bool Remove(IProduct product);

        IProduct Find(int index);

        IProduct FindByLabel(string label);

        IProduct FindMostExpensiveProduct();

        IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi);

        IEnumerable<IProduct> FindAllByPrice(decimal price);

        IEnumerable<IProduct> FindAllByQuantity(int quantity);
    }
}
