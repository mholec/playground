using System;

namespace UkazkaAspNetCore._DependencyInjection
{
	public class ConsoleMailer : IMailer
	{
		public void SendMail(string to, string subject, string body)
		{
			Console.WriteLine("To: " + to);
			Console.WriteLine("Subject: " + subject);
			Console.WriteLine("Body: " + body);
		}
	}
}
