using System.Linq;
using Lib.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class InMemoryTests : UnitTestBase
	{
		[TestMethod]
		public void TestMethod1()
		{
			using (var dbc = new AppDbContext(GetInMemoryOptions()))
			{
				Eshop eshop = dbc.Eshops.Add(new Eshop() { Title = "Test" }).Entity;
				dbc.SaveChanges();

				Assert.IsTrue(eshop.EshopId == 1);
			}
		}
	}
}
