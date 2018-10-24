using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}