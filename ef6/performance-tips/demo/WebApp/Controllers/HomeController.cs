using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
	    private readonly DemoContext db;

	    public HomeController()
	    {
		    db = new DemoContext();
	    }

        public ActionResult Index()
        {
	        var userWithGroups = db.Users
		        .Include(x => x.UserGroups.Select(y => y.Group));


	        List<User> data = db.Users.ToList();

			//User user = db.Users.FirstOrDefault(x => x.Id == 1);

	        string name = db.Users.Where(x => x.Id == 1)
		        .Select(x => x.Firstname)
		        .FirstOrDefault();

			//string name = db.Users.FirstOrDefault(x => x.Id == 1)?.Firstname;

	        DbSet<User>         u1 = db.Users;
	        DbQuery<User>       u2 = db.Users.Include("x");
	        IQueryable<User>    u3 = db.Users.AsQueryable();
	        IEnumerable<User> u4 = db.Users.AsEnumerable().Where(x => x.Id < 10);

	        IEnumerator<User> s = u4.GetEnumerator();
	        s.MoveNext();

	        List<User>          u5 = db.Users.ToList();


	        var users = db.Users.Where(x => x.Id < 10);
	        foreach (var user in users)
	        {
				// todo
	        }


	        var tmp = users.GetEnumerator();
	        while (tmp.MoveNext())
	        {
		        User user = tmp.Current;
	        }
			tmp.Dispose();

			var ex2 = data.Where(x => x.UserGroups.Any(y => y.Group.Name == "xy")).ToList();


	        var data1 = db.Groups.Include(x => x.UserGroups.Select(y => y.User)).FirstOrDefault(x => x.Id == 1);

	        var data2 = db.Groups.AsNoTracking().FirstOrDefault(x=> x.Id == 1);
	        var groups2 = db.UserGroups.AsNoTracking().Where(x => x.GroupId == data2.Id).Select(x => x.User).ToList();

	        var data3 = db.Groups.AsNoTracking().FirstOrDefault(x => x.Id == 1);
	        db.Entry(data3).Collection(x=> x.UserGroups).Load();




	        return View(data2);
        }

	    public ActionResult Index2()
	    {
		    var result = db.Users.Select(x=> new {x.Id, x.Lastname})
			    .ToDictionary(x => x.Id, x => x.Lastname);


			var ex1 = db.Users.ToList();

		    return View(ex1);
	    }

		public class Name
	    {
			public string Nama { get; set; }
	    }

	    private JsonResult JsonData(object data)
	    {
		    return Json(data, JsonRequestBehavior.AllowGet);
	    }
    }
}
