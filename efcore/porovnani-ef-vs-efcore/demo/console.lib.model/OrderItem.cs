﻿namespace console.lib.model
{
	public class OrderItem
	{
		public int OrderItemId { get; set; }
		public int? OrderId { get; set; }
		public Order Order { get; set; }
	}
}