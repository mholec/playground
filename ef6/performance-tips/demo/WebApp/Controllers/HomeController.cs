using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Model;
using Z.EntityFramework.Plus;

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
            var methods = this.GetType().GetMethods().Where(x=> x.DeclaringType == this.GetType()).ToArray();

			return View(methods);
        }

	    public ActionResult Profiling()
	    {
		    var all = db.Users.Include(x => x.UserGroups);

		    string sqlQuery = all.ToString();

		    var result = all.ToList();

		    return null;
	    }

	    public ActionResult Projekce_Before()
	    {
		    var users = db.Users;

		    foreach (var user in users)
		    {
			    var viewModel = new UserVM()
			    {
				    Firstname = user.Firstname,
				    Lastname = user.Lastname
			    };

				List<string> groups = new List<string>();
			    foreach (var result in user.UserGroups.Select(x=> x.Group))
			    {
				    groups.Add(result.Name);
			    }

			    viewModel.Groups = groups;
		    }

		    return null;
	    }

	    public ActionResult Projekce_After()
	    {
		    var users = db.Users.Include(x => x.UserGroups.Select(y => y.Group));

		    var result = users.Select(x => new UserVM()
		    {
				Lastname = x.Lastname,
				Firstname = x.Firstname,
				Groups = x.UserGroups.Select(y=> y.Group.Name).ToList()
		    }).ToList();

		    return null;
	    }


	    public ActionResult Projekce_ToDictionary()
	    {
			// do not
		    var dict1 = db.Users.ToDictionary(x => x.Id, x => x.DateOfBirth);

			// do
			var dict2 = db.Users.Select(x=> new {x.Id, x.DateOfBirth}).ToDictionary(x => x.Id, x => x.DateOfBirth);

			return null;
	    }

		public ActionResult Selekce()
		{
			IQueryable<User> users = db.Users.Where(x => x.DateOfBirth < new DateTime(2010, 1, 1));

			if (true)
			{
				users = users.Where(x => x.Firstname != null && x.Lastname != null);
			}

			var d1 = users.OrderBy(x => x.DateOfBirth).Select(x=> new {x.Firstname, x.Lastname}).Take(5).ToList();
			int[] d2 = users.Select(x => x.Id).ToArray();

		    return null;
	    }


	    public ActionResult LazyLoading_Loop_Before()
	    {
		    var group = db.Groups.FirstOrDefault(x => x.Id == 1);

			List<User> users = new List<User>();
		    foreach (var user in group.UserGroups.Select(y=> y.User))
		    {
			    if (user.DateOfBirth < new DateTime(2010, 1, 1))
			    {
					users.Add(user);
			    }
		    }

		    return null;
	    }

	    public ActionResult EagerLoading_Loop_After()
	    {
		    var users = db.Users										// by users
			    .Include(x => x.UserGroups.Select(y => y.Group))		// include - eager - JOIN
			    .Where(x => x.UserGroups.Any(y => y.GroupId == 1) && x.DateOfBirth < new DateTime(2010, 1, 1))		// selection
		        .Select(x=> new {x.Firstname, x.Lastname})
			    .ToList();												// * projection

		    return null;
	    }

	    public ActionResult DetectChanges_Loop()
	    {
		    Stopwatch sw = new Stopwatch();
		    var data = db.Users.ToList();

			sw.Start();
		    foreach (var user in data)
		    {
			    db.Users.Add(user);
		    }
			sw.Stop();
		    long elapsed1 = sw.ElapsedMilliseconds;
			sw.Reset();


			sw.Start();
		    db.Users.AddRange(data);
		    sw.Stop();
		    long elapsed2 = sw.ElapsedMilliseconds;
		    sw.Reset();

		    sw.Start();
			db.Configuration.AutoDetectChangesEnabled = false;
		    foreach (var user in data)
		    {
			    db.Users.Add(user);
		    }
		    db.Configuration.AutoDetectChangesEnabled = true;
		    sw.Stop();
		    long elapsed3 = sw.ElapsedMilliseconds;
		    sw.Reset();


			return null;
	    }

	    public ActionResult EntityState_Delete()
	    {
		    Stopwatch sw = new Stopwatch();



			sw.Start();
			var usersToDelete = db.Users.Take(10).ToList();
			foreach (var user in usersToDelete)
			{
				db.Users.Remove(user);
			}
			sw.Stop();
			long elapsed1 = sw.ElapsedMilliseconds;
			sw.Reset();



			sw.Start();
			usersToDelete = db.Users.Take(10).ToList();
			db.Users.RemoveRange(usersToDelete);
			sw.Stop();
			long elapsed2 = sw.ElapsedMilliseconds;
			sw.Reset();


			sw.Start();
			var idsToDelete = db.Users.Select(x => x.Id).Take(10);

            foreach (var i in idsToDelete)
		    {
			    db.Entry(new User() {Id = i}).State = EntityState.Deleted;
		    }
		    sw.Stop();
		    long elapsed3 = sw.ElapsedMilliseconds;
	        sw.Reset();

	        //db.SaveChanges(); // !! transaction!!

	        // int deleted = db.Users.Where(x => x.Id < 30).Delete(); // EF.Plus - 1 sql query

            return null;
	    }

        public ActionResult EntityState_Update()
        {
            var changedUser = new User()
            {
                Id = 1,                         // identifier (WHERE Id = 1)
                Lastname = "Holec 2019"         // changed value
                                                // other values = unchanged (default values)
            };
            db.Entry(changedUser).State = EntityState.Modified;
            db.SaveChanges();   // update dbo.Users...

            // db.Users.Where(x => x.Id < 15).Update(x => new User() { Lastname = "H" }); // update only lastname

            return null;
        }

        public ActionResult EfPlus_BulkInsert()
        {
            var user1 = new User(){DateOfBirth = DateTime.Now, Firstname = "M", Lastname = "H"};
            var user2 = new User()
            {
                DateOfBirth = DateTime.Now, Firstname = "M", Lastname = "H",
                UserGroups = new List<UserGroup>()
                {
                    new UserGroup()
                    {
                        Added = DateTime.Now,
                        Group = new Group()
                        {
                            Name = "Test 1",
                            Description = "Bulk test"
                        }
                    }
                }
            };


            db.BulkInsert(new[] {user1, user2});

            var usr = db.Users.FirstOrDefault(x => x.Id == user2.Id);

            return null;
        }

        public class UserVM
	    {
		    public string Firstname { get; set; }
		    public string Lastname { get; set; }

			public List<string> Groups { get; set; }
		}
    }
}
