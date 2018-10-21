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
    [Route("api/[controller]")]
    public class AdvancedController : ControllerBase
    {
		private readonly Context appContext;

	    public AdvancedController(Context appContext)
	    {
		    this.appContext = appContext;
	    }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
	        var requestCulture = HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture;

			List<Product> products = await appContext.Products.Include(x => x.Tags)
			    .Where(x=> x.Language == requestCulture.Culture.Name)
			    .ToListAsync();

	        return Ok(products);
        }
	}
}
