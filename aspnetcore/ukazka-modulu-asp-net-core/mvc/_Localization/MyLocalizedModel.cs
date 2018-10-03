using System.ComponentModel.DataAnnotations;

namespace UkazkaAspNetCore._Localization
{
	public class MyLocalizedModel
	{
		[Required(ErrorMessage = "The Email field is required.")]
		[EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}
