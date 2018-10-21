using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace UkazkaAspNetCore._Localization
{
    public class LanguageCustomController : Controller
    {
	    private readonly IStringLocalizer localizer;

	    public LanguageCustomController(IStringLocalizerFactory localizerFactory)
	    {
		    localizer = localizerFactory.Create(typeof(SharedResource));

			// var type = typeof(SharedResource);
		    // var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
		    // localizer = localizerFactory.Create("SharedResource", assemblyName.Name);
		}

		[Route("language/custom")]
		[HttpGet]
		public IActionResult Index()
        {
            return Ok(localizer["Hello world"]);
        }
	}
}