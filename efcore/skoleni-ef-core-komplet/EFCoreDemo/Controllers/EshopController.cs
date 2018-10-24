using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo.Controllers
{
    public class EshopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}