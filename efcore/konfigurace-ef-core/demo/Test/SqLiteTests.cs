using System.Diagnostics;
using Lib.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class SqliteTests : UnitTestBase
	{
		private readonly AppDbContext dbcontext;

		public SqliteTests()
		{
			dbcontext = new AppDbContext(GetSqlliteOptions());
		}

		[TestInitialize]
		public void TestInitialize()
		{
			// pro každý test odstranit data (izolace testù)
			dbcontext.Database.EnsureDeleted();
			dbcontext.Database.EnsureCreated();
		}

		[TestMethod]
		public void TestMethod1()
		{
			Eshop eshop = dbcontext.Eshops.Add(new Eshop() { Title = "Test" }).Entity;
			dbcontext.SaveChanges();

			Assert.IsTrue(eshop.EshopId == 1);
		}

		[TestMethod]
		public void TestMethod2()
		{
			Eshop eshop = dbcontext.Eshops.Add(new Eshop() { Title = "Test" }).Entity;
			dbcontext.SaveChanges();

			Assert.IsTrue(eshop.EshopId == 1);
		}

		[TestMethod]
		public void TestMethod3()
		{
			// jiná varianta vytvoøení konextu, životnost se øídí v metodì GetSqliteDbContext()
			using (var dbc = GetSqliteDbContext())
			{
				Eshop eshop = dbc.Eshops.Add(new Eshop() { Title = "Test" }).Entity;
				dbc.SaveChanges();

				Assert.IsTrue(eshop.EshopId == 1);
			}
		}
	}
}