using System;

namespace EFCoreDemo.Data.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        public int? OriginalProductId { get; set; }
        public string Title { get; set; }
        public Price Price { get; set; }
        public int Amount { get; set; }
        public Price TotalPrice { get; set; }
        
        public Product OriginalProduct { get; set; }
        public Order Order { get; set; }
    }
}