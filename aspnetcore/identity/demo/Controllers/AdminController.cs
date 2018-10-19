using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
	[Authorize]
	public class AdminController : Controller
	{
		[Route("admin")]
		// žádná role není vyžadována, ale dědí [Authorize]
		public IActionResult Admin()
		{
			return Ok("this is admin page");
		}

		[Route("editor")]
		[Authorize(Roles = "Editor")]
		public IActionResult Editor()
		{
			return Ok("this is editor page");
		}

		[Route("special")]
		[Authorize(Roles = "Administrator,Editor")]
		public IActionResult Special()
		{
			return Ok("this is page for admin and editor");
		}

		[Route("anonymous")]
		[AllowAnonymous]
		public IActionResult Anonymous()
		{
			return Ok("this is anonymous page");
		}

		[Route("policies")]
		[Authorize("CustomPolicy")]
		public IActionResult Policies()
		{
			return Ok("this is policy page");
		}
	}
}
