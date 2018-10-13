using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using demo.Services;
using demo.Services.Generators;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    public class HomeController : Controller
    {
	    private readonly GuidService guidService;
	    private readonly IScopedGuidGen scopedGuidGen;
	    private readonly ITransientGuidGen transientGuidGen;
	    private readonly ISingletonGuidGen singletonGuidGen;


	    public HomeController(GuidService guidService, IScopedGuidGen scopedGuidGen, ITransientGuidGen transientGuidGen, ISingletonGuidGen singletonGuidGen)
	    {
		    this.guidService = guidService;
		    this.scopedGuidGen = scopedGuidGen;
		    this.transientGuidGen = transientGuidGen;
		    this.singletonGuidGen = singletonGuidGen;
	    }

	    [Route("")]
        public IActionResult Index()
		{
			List<KeyValuePair<string, string>> results = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("GS transient", guidService.Transient.GetGuid()),
				new KeyValuePair<string, string>("DI transient", transientGuidGen.GetGuid()),

				new KeyValuePair<string, string>("GS scoped", guidService.Scoped.GetGuid()),
				new KeyValuePair<string, string>("DI scoped", scopedGuidGen.GetGuid()),

				new KeyValuePair<string, string>("GS singleton", guidService.Singleton.GetGuid()),
				new KeyValuePair<string, string>("DI singleton", singletonGuidGen.GetGuid())
			};




			return Ok(results);
		}
	}
}