using System;
using Microsoft.AspNetCore.Mvc;

namespace UkazkaAspNetCore._DependencyInjection
{
    public class MailerController : Controller
    {
	    private readonly IMailer mailer;

	    public MailerController(IMailer mailer)
	    {
		    this.mailer = mailer;
	    }

		[Route("mailer")]
	    public IActionResult Index()
		{
			try
			{
				mailer.SendMail("to@mail.cz", "Hello!", "Nice message");
			}
			catch (Exception)
			{
				return Ok("Error");
			}

            return Ok("OK");
        }
    }
}