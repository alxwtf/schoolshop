using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public List<CartSelectViewModel> Carts { get; set; }
    }
    public class CartSelectViewModel
    {
        public int CartId { get; set; }
        public int Number { get; set; }
    }
}
