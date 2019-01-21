using WebApp.Services;

namespace WebApp.Facades
{
    public class MyFacade
    {
        private readonly IMailService mail;

        public MyFacade(IMailService mail)
        {
            this.mail = mail;
        }

        public HomeViewModel GetHomepage()
        {
            mail.SendEmail();

            return new HomeViewModel();
        }
    }
}