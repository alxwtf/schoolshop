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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddtoCart(int id)
        {
            var product = db.Products.Where(x => x.Id == id);
            var model = db.Orders
                .Where(x=>x.Status==OrderStatus.NotPaid)
                .OrderByDescending(x=>x.OrderDate)
                .ToList();
            var viewmodel = product
                .Select(x => new ProductViewModel
                {
                    Carts = model
                    .Select(y => new OrderSelectViewModel
                    {
                        CartId = y.Id,
                        Number = y.Number
                    }).ToList(),
                    ProductId = x.Id
                }).FirstOrDefault();
            return PartialView(viewmodel);
        }

        [HttpGet]
        public ActionResult<bool> Confirm(int? id, int ProdId)
        {
            if (id == null)
            {
                var order = new Order
                {
                    Number = DateTime.Now.ToString("yyyyMMdd-HHmmss"),
                    OrderDate = DateTime.Now
                };
                db.Orders.Add(order);
                var item = new OrderItem
                {
                    ProductId = ProdId,
                    OrderId = order.Id,
                    Count = 1
                };
                db.OrderItems.Add(item);
            }
            else
            {
                var item = db.OrderItems.Where(x => x.ProductId == ProdId && x.OrderId == id).FirstOrDefault();
                if (item != null)
                {
                    item.Count++;
                }
                else
                {
                    var additem = new OrderItem
                    {
                        ProductId = ProdId,
                        OrderId = (int)id,
                        Count = 1,
                    };
                    db.OrderItems.Add(additem);
                }
            }
            db.SaveChanges();
            return true;
        }

    }
}