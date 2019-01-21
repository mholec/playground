using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Services;

namespace WebApp.Installers
{
    public interface IMailServiceFactory
    {
        IMailService GetMailService(string key);
    }
}