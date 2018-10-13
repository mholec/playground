using Lib.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class InMemoryTests : UnitTestBase
	{
		[TestMethod]
		public void TestMethod1()
		{
			using (var dbc = GetInMemoryDbContext("AAA"))
			{
				Eshop eshop = dbc.Eshops.Add(new Eshop() { Title = "Test" }).Entity;
				dbc.SaveChanges();

				Assert.IsTrue(eshop.EshopId == 1);
			}
		}

		[TestMethod]
		public void TestMethod2()
		{
			using (var dbc = GetInMemoryDbContext("BBB"))
			{
				Eshop eshop = dbc.Eshops.Add(new Eshop() { Title = "Test" }).Entity;
				dbc.SaveChanges();

				Assert.IsTrue(eshop.EshopId == 1);
			}
		}
	}
}
