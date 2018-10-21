using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace UkazkaAspNetCore._Localization
{
    public class LanguageController : Controller
    {
	    private readonly IStringLocalizer<LanguageController> localizer;
	    private readonly IHtmlLocalizer<LanguageController> htmlLocalizer;

	    public LanguageController(IStringLocalizer<LanguageController> localizer,
		    IHtmlLocalizer<LanguageController> htmlLocalizer)
	    {
		    this.localizer = localizer;
		    this.htmlLocalizer = htmlLocalizer;
	    }

	    [Route("language/text")]
		public IActionResult Text()
        {
	        string name = "Miroslav";

			return Ok(localizer["My name is {0}", name]);
        }

	    [Route("language/html")]
	    public IActionResult Html()
	    {
		    return Ok(htmlLocalizer["My <b>name</b> is Miroslav"]);
	    }

	    [Route("language/view")]
	    public IActionResult RazorView()
	    {
		    return View("~/_Localization/View.cshtml");
	    }

	    [Route("language/view")]
	    [HttpPost]
	    public IActionResult RazorView(MyLocalizedModel model)
	    {
		    var errors = ModelState.Select(x => x.Value.Errors)
			    .Where(x => x.Count > 0)
			    .ToList();

		    return Ok(errors);
	    }
    }
}