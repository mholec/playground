namespace UkazkaAspNetCore._DependencyInjection
{
	public interface IMailer
	{
		void SendMail(string to, string subject, string body);
	}
}
