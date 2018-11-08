using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class OrderViewModel
    {
        public string Number { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
        public decimal TotalSum => OrderItems.Sum(x => x.TotalSum);
    }
    public class OrderItemViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalSum => Price * Count;
        public Order order { get; set; }
    }
}
