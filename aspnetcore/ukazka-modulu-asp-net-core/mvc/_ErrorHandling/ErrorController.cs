using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace UkazkaAspNetCore._ErrorHandling
{
    public class ErrorController : Controller
    {
	    [Route("error/simulate")]
		public IActionResult Simulate()
        {
	        using (var streamReader = new StreamReader("x:/slozka"))
	        {
		        return Ok(streamReader.ReadToEnd());
			}
		}

	    [Route("error/simulate2")]
	    public IActionResult Simulate2()
	    {
		    int num = 1 - 2;
		    return Ok(9 / (1 + num));
	    }
	}
}