using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    public class TestController : Controller
    {
        ShopContext db;
        public IActionResult Index()
        {
            var products = db.Products;
            return View(products);
        }
    }
}