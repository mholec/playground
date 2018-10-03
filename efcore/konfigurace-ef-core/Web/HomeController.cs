using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web
{
	public class HomeController : Controller
	{
		[Route("")]
		public IActionResult Index()
		{
			return Ok("OK");
		}
	}
}
