using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
	public class HomeController : Controller
	{
		[Route("")]
		public IActionResult Index()
		{
			return View("~/Views/Index.cshtml");
		}
	}
}
