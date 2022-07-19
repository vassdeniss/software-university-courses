using System.Collections.Generic;

namespace FastFood.Web.ViewModels.Orders
{
    public class CreateOrderViewModel
    {
        public List<int> Items { get; set; }

        public List<int> Employees { get; set; }
    }
}
