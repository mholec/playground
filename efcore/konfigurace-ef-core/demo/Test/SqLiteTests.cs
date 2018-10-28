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
			// pro ka�d� test odstranit data (izolace test�)
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
			// jin� varianta vytvo�en� konextu, �ivotnost se ��d� v metod� GetSqliteDbContext()
			using (var dbc = GetSqliteDbContext())
			{
				Eshop eshop = dbc.Eshops.Add(new Eshop() { Title = "Test" }).Entity;
				dbc.SaveChanges();

				Assert.IsTrue(eshop.EshopId == 1);
			}
		}
	}
}