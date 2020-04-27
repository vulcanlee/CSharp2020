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

        public Task<IEnumerable<Order>> GetAsync()
        {
            return Task.FromResult(Items.AsEnumerable());
        }
        public Task<Order> GetAsync(int orderID)
        {
            var item = Items.FirstOrDefault(x => x.OrderID == orderID);
            return Task.FromResult(item);
        }
        public Task AddAsync(Order order)
        {
            Items.Insert(0,order);
            return Task.CompletedTask;
        }
        public Task UpdateAsync(Order order)
        {
            var item =Items.FirstOrDefault(x=>x.OrderID == order.OrderID);
            item.Freight = order.Freight;
            item.CustomerID = order.CustomerID;

            return Task.CompletedTask;
        }
        public Task DeleteAsync(Order order)
        {
            var item = Items.FirstOrDefault(x => x.OrderID == order.OrderID);
            Items.Remove(item);
            return Task.CompletedTask;
        }
    }
}
