using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    public class ViewController : Controller
    {
		[Route("view")]
        public IActionResult Index()
        {
            return View("~/Views/View.cshtml");
        }
    }
}