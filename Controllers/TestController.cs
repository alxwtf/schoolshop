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
    public class TestController : Controller
    {
        ShopContext db;

        public TestController(ShopContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var products = db
                .Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddToCart(int id)
        {
            var order = db.Orders.ToList();
            TempData["productid"] = id;
            return View(order);
        }

        [HttpPost]
        public IActionResult Confirm(int? id)
        {
            if (id == null)
            {
                var CountCarts = db.Orders.Select(x => x.Number).Count();
                CountCarts++;
                var order = new Order
                {
                    Number = CountCarts.ToString(),
                    Items = new List<OrderItem>
                    {
                        new OrderItem{
                        ProductId = (int)TempData["productid"],
                        OrderId = CountCarts,
                        Count = 1
                        }
                    }
                };
                db.Orders.Add(order);
            }
            else
            {
                var item = db.OrderItems.Where(x => x.ProductId == (int)TempData["productid"] && x.OrderId == id).FirstOrDefault();
                if (item != null)
                {
                    item.Count++;
                }
                else
                {
                    var additem = new OrderItem
                    {
                        ProductId = (int)TempData["productid"],
                        OrderId = (int)id,
                        Count = 1,

                    };
                    db.OrderItems.Add(additem);
                }
            }
            db.SaveChanges();
            TempData.Clear();
            return RedirectToAction("index");
        }

        public IActionResult Cart(int id) {
            var model = db.Orders.ToList();
            return View(model);
        }

        public IActionResult ShowCartItems(int id) {
            var model = db.Orders
                .Include(x => x.Items)
                .ThenInclude(y => y.Product)
                .Where(x=>x.Id==id)
                .ToList();
            var viewModel = model
                .Select(x =>
                new CartViewModel
                {
                    CartId = x.Id,
                    items = x.Items
                        .Select(y => new CartItemsViewModel
                        {
                            Name = y.Product.Name,
                            Price = y.Product.Price,
                            Count = y.Count
                        }
                        ).ToList()
                });
            return PartialView(viewModel);
        }

        [HttpPost]
        public IActionResult Check(int id)
        {
            var model = db.Orders
                .Include(x => x.Items)
                .ThenInclude(y => y.Product)
                .Where(x=>x.Id==id)
                .ToList();
            var viewModel = model
                .Select(x =>
                new CartViewModel
                {
                    CartId = x.Id,
                    items = x.Items
                        .Select(y => new CartItemsViewModel
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