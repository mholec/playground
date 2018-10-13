using demo.Filters;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
	[TypeFilter(typeof(MyActionFilter))]
	public class FilterController : Controller
    {
		[Route("filters")]
        public IActionResult Index()
		{
			return Ok("OK");
		}
    }
}