using System;
using System.Collections.Generic;

namespace EFCoreDemo.Data.Models
{
    public class Order
    {
        public Order()
        {
            OrderId = Guid.NewGuid();
            Created = DateTime.Now;
        }
        
        public Guid OrderId { get; set; }
        public Price Price { get; set; }
        public DateTime Created { get; set; }
        
        public int OrderNo { get; set; } 
        
        public OrderState OrderState { get; set; }
        
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        
        public List<OrderItem> OrderItems { get; set; }
    }
}