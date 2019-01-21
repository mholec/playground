using System;

namespace WebApp.Services
{
    public class DebugMailService : IMailService
    {
        public void SendEmail()
        {
            Console.WriteLine("OK, zavoláno");
        }
    }
}