using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Model
{
	public class Eshop
	{
		// PK
		public int EshopId { get; set; }

		// Property
		public string Title { get; set; }

		// Navigation Property
		public List<Product> Products { get; set; }
	}
}
