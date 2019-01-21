using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebApp.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings settings;

        public MailService(MailSettings mailSettings)
        {
            settings = mailSettings;
        }

        public void SendEmail()
        {
            SmtpClient smtp = new SmtpClient();

            smtp.Send(new MailMessage());
        }
    }
}