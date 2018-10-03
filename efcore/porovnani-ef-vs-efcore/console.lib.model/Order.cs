using System.Collections.Generic;

namespace console.lib.model
{
    public class Order
    {
		public int OrderId { get; set; }
		public string Identifier { get; set; }
		public HashSet<OrderItem> Items { get; set; }
    }
}
