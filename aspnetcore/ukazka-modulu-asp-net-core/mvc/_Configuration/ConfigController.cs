using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace UkazkaAspNetCore._Configuration
{
    public class ConfigController : ControllerBase
    {
	    private readonly AppSettings appSettings;
	    private readonly SmtpSettings smtpSettings;
	    private readonly IConfiguration configuration;

	    public ConfigController(
		    IOptions<AppSettings> appSettings, 
		    IOptions<SmtpSettings> smtpSettings,
		    IConfiguration configuration)
	    {
		    this.appSettings = appSettings.Value;
		    this.smtpSettings = smtpSettings.Value;
		    this.configuration = configuration;
	    }

	    [Route("config")]
		public IActionResult Index()
	    {
		    return Ok(smtpSettings);
	    }

		[Route("config/value/{key}")]
		public IActionResult Value(string key)
	    {
		    return Ok(configuration[key]);
	    }

	}
}
