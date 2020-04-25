using Syncfusion.Blazor.Navigations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzsfSimpleCRUD.Data
{
    public class OrderService
    {
        List<Order> Items { get; set; } = new List<Order>();
        public OrderService()
        {
            Items = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 2.1 * x,
            }).ToList();
        }

        public IEnumerable<Order> GetItems()
        {
            return Items;
        }
        public Task<Order> Get(int orderID)
        {
            var item = Items.FirstOrDefault(x => x.OrderID == orderID);
            return Task.FromResult(item);
        }
        public Task Add(Order order)
        {
            Items.Add(order);
            return Task.CompletedTask;
        }
        public Task Remove(Order order)
        {
            Items.Remove(order);
            return Task.CompletedTask;
        }
        public void Remove()
        {
            Items.RemoveRange(1, 50);
            Items[0].CustomerID = "Vulcan Lee";
        }
    }
}
