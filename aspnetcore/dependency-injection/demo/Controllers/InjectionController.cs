using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Services.Generators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace demo.Controllers
{
    public class InjectionController : Controller
    {
	    private readonly ITransientGuidGen transient1;

	    public InjectionController(ITransientGuidGen transient1)
	    {
		    this.transient1 = transient1;
	    }

	    [Route("injection")]
        public IActionResult Special([FromServices]ITransientGuidGen transient2)
	    {
		    var transient3 = HttpContext.RequestServices.GetService<ITransientGuidGen>();

		    var example = new
		    {
				transient1 = transient1.GetGuid(),
				transient2 = transient2.GetGuid(),
				transient3 = transient3.GetGuid()
		    };

		    return Ok(example);
	    }
    }









	public class ExampleInjectionService
	{
		private readonly IServiceProvider serviceProvider;

		public ExampleInjectionService(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public string GetGuid()
		{
			ITransientGuidGen transientGuidGen = serviceProvider.GetService<ITransientGuidGen>();

			return transientGuidGen.GetGuid();
		}
	}
}