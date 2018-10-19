using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using demo.Model.CustomIdentity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<WebAppUser> userManager;
		private readonly SignInManager<WebAppUser> signInManager;

		public AccountController(UserManager<WebAppUser> userManager, SignInManager<WebAppUser> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		[Route("account/login")]
		[HttpGet]
		public IActionResult Login()
		{
			return View("~/Views/Login.cshtml");
		}

		[Route("account/login")]
		[HttpPost]
		public async Task<IActionResult> Login(string username, string password)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Role, "Administrator"),
				new Claim(ClaimTypes.Role, "Editor")
			};

			var user = new WebAppUser()
			{
				Name = "Anonymous",
				UserName = username,
				Claims = claims.Take(0).Select(x=> new IdentityUserClaim<string>()
				{
					ClaimType = x.Type,
					ClaimValue = x.Value
				}).ToList()
			};

			var result = await userManager.CreateAsync(user, password);
			if (!result.Succeeded)
			{
				var errors = result.Errors.ToList();
			}

			await signInManager.PasswordSignInAsync(user, password, true, false);
			//await signInManager.SignInAsync(user, true);

			// post-redirect-get pattern (cookie)
			return RedirectToAction("Index", "Home");
		}

		[Route("account/logout")]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();

			return RedirectToAction("Index", "Home");
		}

		[Route("account/accessdenied")]
		public IActionResult AccessDenied()
		{
			return View("~/Views/AccessDenied.cshtml");
		}
	}
}