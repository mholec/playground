using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo.Controllers
{
    public class BrandsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}