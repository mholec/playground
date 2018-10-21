using Newtonsoft.Json;

namespace UkazkaAspNetCore._Configuration
{
	public class SmtpSettings
	{
		public string SmtpServer { get; set; }
		public int SmtpPort { get; set; }
		public string SmtpUser { get; set; }
		public string SmtpPassword { get; set; }

		[JsonProperty("SmtpUseSSL")]
		public bool SmtpUseSsl { get; set; }
	}
}
