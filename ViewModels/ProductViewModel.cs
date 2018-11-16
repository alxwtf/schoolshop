using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;

namespace Shop.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public List<OrderSelectViewModel> Carts { get; set; }
    }
    public class OrderSelectViewModel
    {
        public int CartId { get; set; }
        public string Number { get; set; }
        public OrderStatus Status { get; set; }
    }
}
