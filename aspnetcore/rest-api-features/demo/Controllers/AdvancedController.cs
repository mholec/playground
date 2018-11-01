using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.ApiModels;
using demo.Repositories;
using demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo.Controllers
{
    [ApiController]
    [ResponseCache(Duration = 1200)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
	public class AdvancedController : ControllerBase
    {
		private readonly Context appContext;

	    public AdvancedController(Context appContext)
	    {
		    this.appContext = appContext;
	    }

		[HttpGet/*, MapToApiVersion("1.0")*/]
		public IActionResult VersioningDemo(int version)
	    {
		    if (version == 1)
		    {

		    }


		    return Ok(new {Data = "verze 1.0"});
	    }

	 //   [HttpGet, MapToApiVersion("2.0")]
	 //   public IActionResult VersioningDemoV2()
	 //   {
		//	return Ok(new { Data = "verze 2.0" });
		//}

		//[HttpGet]
  //      public async Task<ActionResult<List<Product>>> Get()
  //      {
	 //       var requestCulture = HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture;

		//	List<Product> products = await appContext.Products.Include(x => x.Tags)
		//	    .Where(x=> x.Language == requestCulture.Culture.Name)
		//	    .ToListAsync();

	 //       return Ok(products);
  //      }
	}
}
