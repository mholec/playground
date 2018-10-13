using System.Linq;
using System.Threading.Tasks;
using demo.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
	public class ResourceController : Controller
	{
		private readonly IAuthorizationService authorizationService;

		public ResourceController(IAuthorizationService authorizationService)
		{
			this.authorizationService = authorizationService;
		}

		[Route("resource")]
		public async Task<IActionResult> Index()
		{
			var data = new DataSource();

			var document = data.Documents.FirstOrDefault();

			var result = await authorizationService.AuthorizeAsync(User, document, "DocumentManagePolicy");

			if (result.Succeeded)
			{
				if (User.Identity.IsAuthenticated)
				{
					return Forbid();
				}
				else
				{
					return Challenge();
				}
			}

			return View();
		}
	}
}