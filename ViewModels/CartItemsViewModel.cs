using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class CartItemsViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalSum => Price * Count;
    }
    public class CartViewModel
    {
        public List<CartItemsViewModel> items;
        public decimal TotalSum => items.Sum(x => x.TotalSum);
        public int CartId { get;set; }
        public int Number { get;set; }
        public ProductViewModel ProductInfo { get; set; }
    }
}
