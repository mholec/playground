using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace UkazkaAspNetCore.Home
{
    public class HomeController : Controller
    {
		[Route("")]
        public IActionResult Index()
        {
            return View("~/Home/Index.cshtml");
        }
    }
}
