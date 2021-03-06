using System;
using OrderViewer.Core.Enums;

namespace OrderViewer.API.Models.Order
{
    public class OrderDto
    {
        public long Id { get; set; }
        
        public OrderStatus OrderStatus { get; set; }
        
        public DateTime Timestamp { get; set; }
    }
}