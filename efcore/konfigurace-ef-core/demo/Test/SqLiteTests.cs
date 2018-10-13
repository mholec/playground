using System.Diagnostics;
using Lib.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class SqliteTests : UnitTestBase
	{
		private AppDbContext dbcontext;

		[TestInitialize]
		public void TestInitialize()
		{
			dbcontext = GetSqliteDbContext("AAAB");
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
			using (var dbc = GetSqliteDbContext())
			{
				Eshop eshop = dbc.Eshops.Add(new Eshop() { Title = "Test" }).Entity;
				dbc.SaveChanges();

				Assert.IsTrue(eshop.EshopId == 1);
			}
		}
	}
}