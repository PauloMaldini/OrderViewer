using System;
using OrderViewer.API.Models.OrderItem.Base;

namespace OrderViewer.API.Models.OrderItem
{
    public class OrderItemDto : OrderItemDtoBase
    {
        public long Id { get; set; }
        
        public string ProductName { get; set; }
    }
}