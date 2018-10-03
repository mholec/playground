using System.Collections.Generic;
using System.Linq;
using console.lib.model;
using System.Data.Entity;

namespace console.lib.ef6
{
	public class OrderRepository
	{
		private readonly Ef6DbContext dbContext;

		public OrderRepository(Ef6DbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public List<Order> GetOrders()
		{
			return dbContext.Orders.Include(x => x.Items).ToList();
		}

		public List<OrderItem> GetOrderItems()
		{
			return dbContext.OrderItems.Include(x => x.Order).ToList();
		}
	}
}
