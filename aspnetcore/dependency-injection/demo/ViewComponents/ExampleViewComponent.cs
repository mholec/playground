using System.Threading.Tasks;
using demo.Services.Generators;
using Microsoft.AspNetCore.Mvc;

namespace demo.ViewComponents
{
	[ViewComponent(Name = "Example")]
	public class ExampleViewComponent : ViewComponent
	{
		private readonly IScopedGuidGen scopedGuidGen;

		public ExampleViewComponent(IScopedGuidGen scopedGuidGen)
		{
			this.scopedGuidGen = scopedGuidGen;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			string example = "This is great GUID: " + scopedGuidGen.GetGuid();

			return View("~/ViewComponents/ViewComponent.cshtml", example);
		}
	}
}
