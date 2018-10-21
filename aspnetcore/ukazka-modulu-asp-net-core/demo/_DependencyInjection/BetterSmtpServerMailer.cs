using System.Net.Mail;

namespace UkazkaAspNetCore._DependencyInjection
{
	public class BetterSmtpServerMailer : IMailer
	{
		private readonly SmtpClient smtpClient;
		public BetterSmtpServerMailer(SmtpClient smtpClient)
		{
			this.smtpClient = smtpClient;
		}

		public void SendMail(string to, string subject, string body)
		{
			smtpClient.Send("admin@admin.cz", to, subject, body);
		}
	}
}