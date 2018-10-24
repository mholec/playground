using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}