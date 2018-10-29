using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace UkazkaAspNetCore._HttpContext
{
    public class ContextController : Controller
    {
	    private readonly CustomService customService;

	    public ContextController(CustomService customService)
	    {
		    this.customService = customService;
	    }

	    [Route("context")]
        public IActionResult Index()
	    {
			return Ok(customService.GetIdentity());
		}
    }
}