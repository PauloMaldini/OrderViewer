using System;

namespace OrderViewer.API.Models.OrderItem
{
    public class OrderItemDto
    {
        public string ProductName { get; set; }
        
        public int Quantity { get; set; }
        
        public Decimal Price { get; set; }
    }
}