using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Facades;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyFacade facade;

        public HomeController(MyFacade facade)
        {
            this.facade = facade;
        }


        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            var model = facade.GetHomepage();

            return View(model);
        }
    }
}
