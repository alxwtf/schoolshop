using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
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
                .ThenInclude(y => y.Product)
                .Where(x=>x.Status==OrderStatus.NotPaid)
                .OrderByDescending(x=>x.OrderDate)
                .ToList();

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
                        ).ToList(),
                    Id=x.Id,
                    Status=x.Status
                });

            return View(viewModel);
        }

        public IActionResult History()
        {
            var model = db.Orders
                .Include(x => x.Items)
                .ThenInclude(y => y.Product)
                .Where(x => x.Status == OrderStatus.Paid)
                .OrderByDescending(x => x.OrderDate)
                .ToList();

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
                        ).ToList(),
                    Id = x.Id,
                    Status=x.Status
                });

            return View(viewModel);
        }
        
        [HttpGet]
        public ActionResult<bool> Pay(int? id)
        {
            var order = db.Orders.FirstOrDefault(x =>x.Id==id);
            order.Status = OrderStatus.Paid;
            db.SaveChanges();
            return true;
        }
    }
}