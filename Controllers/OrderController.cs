using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        ShopContext db;

        public OrderController(ShopContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var model = db.Orders
                .Include(x => x.Items)
                .ThenInclude(y => y.Product).ToList();

            var viewModel = model
                .Select(x =>
                new OrderViewModel
                {
                    Number = x.Number,
                    OrderItems = x.Items
                        .Select(y => new OrderItemViewModel
                        {
                            Name = y.Product.Name,
                            Price = y.Product.Price,
                            Count = y.Count
                        }
                        ).ToList()
                });

            return View(viewModel);
        }
    }
}