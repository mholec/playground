using demo.Services.Generators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace demo.Filters
{
	public class MyActionFilter : ActionFilterAttribute
	{
		private readonly IScopedGuidGen scopedGuidGen;

		public MyActionFilter(IScopedGuidGen scopedGuidGen)
		{
			this.scopedGuidGen = scopedGuidGen;
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var test = scopedGuidGen.GetGuid();
		}

		public override void OnActionExecuted(ActionExecutedContext context)
		{
			var test = scopedGuidGen.GetGuid();
		}
	}
}
