using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}