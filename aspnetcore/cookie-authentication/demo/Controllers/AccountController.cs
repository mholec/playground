using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
	public class AccountController : Controller
	{
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
			// username + password check

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, username),
				new Claim(ClaimTypes.Role, "Administrator"),
				new Claim(ClaimTypes.Role, "Editor"),
			};

			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			var authProperties = new AuthenticationProperties
			{
				ExpiresUtc = DateTimeOffset.Now.AddDays(1),
				IsPersistent = true,
				RedirectUri = "/"
			};

			await HttpContext
				.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

			return View("~/Views/Index.cshtml");
		}


		[Route("account/logout")]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			return RedirectToAction("Index", "Home");
		}

		[Route("account/accessdenied")]
		public IActionResult AccessDenied()
		{
			return View("~/Views/AccessDenied.cshtml");
		}
	}
}