using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UkazkaAspNetCore._Logging
{
    public class LoggingController : Controller
    {
	    private readonly ILogger<LoggingController> logger;

	    public LoggingController(ILogger<LoggingController> logger)
	    {
		    this.logger = logger;
	    }

	    [Route("logging")]
        public IActionResult Index()
        {
			logger.LogInformation("Index fired!");
			logger.LogWarning("Warning message");
			logger.LogInformation(new ApplicationException("Popis výjimky"), "Message výjimky");
			logger.LogError(new ApplicationException("Popis výjimky"), "Message výjimky");

	        using (logger.BeginScope("Transaction logging, group everything together"))
	        {
		        logger.LogWarning("Log PART 1");

				// logic

		        logger.LogWarning("Log PART 2");
			}

			return Ok();
        }
    }
}