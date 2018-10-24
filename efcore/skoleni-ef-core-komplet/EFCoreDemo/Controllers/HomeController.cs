using System;
using System.Linq;
using System.Reflection;
using EFCoreDemo.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        private DemoDbContext db;

        public HomeController(DemoDbContext dbContext)
        {
            this.db = dbContext;
        }
        
        public IActionResult Index()
        {
            var test = db.Brands.FirstOrDefault()?.GetPaidProductsWithBrand();
            
            return View();
        }

        public string UpdatePrice(decimal price)
        {
            return price.ToString("N0") + " Kč";
        }
    }
}
