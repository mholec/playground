using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using UkazkaAspNetCore._Configuration;

namespace UkazkaAspNetCore._DependencyInjection
{
	public class SmtpServerMailer : IMailer
	{
		private readonly SmtpSettings smtpSettings;
		public SmtpServerMailer(IOptions<SmtpSettings> smtpSettings)
		{
			this.smtpSettings = smtpSettings.Value;
		}

		public void SendMail(string to, string subject, string body)
		{
			using (SmtpClient smtpClient = new SmtpClient(smtpSettings.SmtpServer))
			{
				smtpClient.Port = smtpSettings.SmtpPort;
				smtpClient.Credentials = new NetworkCredential(smtpSettings.SmtpUser, smtpSettings.SmtpPassword);

				smtpClient.Send("admin@admin.cz", to, subject, body);
			}
		}
	}
}