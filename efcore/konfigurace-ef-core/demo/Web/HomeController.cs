using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lib.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web
{
	public class HomeController : Controller
	{
		private readonly AppDbContext appDbContext;

		public HomeController(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		[Route("")]
		public IActionResult Index()
		{
			return Ok("OK");
		}
	}
}
