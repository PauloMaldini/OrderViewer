using System;
using System.Collections.Generic;
using OrderViewer.Core.Enums;

namespace OrderViewer.API.Models.OrderSummary
{
    public class OrderSummaryItemDto
    {
        public string ProductName { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal Price { get; set; }
        
        public decimal TotalPrice { get; set; } 
    }
    
    public class OrderSummaryDto
    {
        public string Number { get; set; }
        
        public DateTime Date { get; set; }
        
        public OrderStatus Status { get; set; }
        
        public string StateName { get; set; }
        
        public decimal TotalPrice { get; set; }
        
        public decimal TotalProductPrice { get; set; }
        
        public int TotalQuantity { get; set; }
        
        public List<OrderSummaryItemDto> Items { get; set; }
    }
}