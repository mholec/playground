using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Model
{
	public class Product
	{
		// PK
		public int ProductId { get; set; }

		// FK
		public int EshopId { get; set; }

		// Property
		public string Title { get; set; }

		// Navigation Property
		public Eshop Eshop { get; set; }
}
}
