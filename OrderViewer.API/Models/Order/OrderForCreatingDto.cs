using System;
using System.Collections.Generic;
using OrderViewer.API.Models.OrderItem;
using OrderViewer.Core.Enums;

namespace OrderViewer.API.Models.Order
{
    public class OrderForCreatingDto
    {
        public OrderStatus OrderStatus { get; set; }
        
        public DateTime Timestamp { get; set; }
    }
}