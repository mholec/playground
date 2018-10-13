using System.Collections.Generic;
using System.Linq;
using console.lib.model;
using Microsoft.EntityFrameworkCore;

namespace console.lib.efcore
{
	public class OrderRepository
	{
		private readonly EfCoreDbContext dbContext;

		public OrderRepository(EfCoreDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public List<Order> GetOrders()
		{
			return dbContext.Orders.Include(x=> x.Items).ToList();
		}

		public List<OrderItem> GetOrderItems()
		{
			return dbContext.OrderItems.Include(x => x.Order).ToList();
		}
	}
}
