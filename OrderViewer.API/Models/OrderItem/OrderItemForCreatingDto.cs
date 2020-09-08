using System;
using OrderViewer.API.Models.OrderItem.Base;

namespace OrderViewer.API.Models.OrderItem
{
    public class OrderItemForCreatingDto : OrderItemDtoBase
    {
        public long OrderId { get; set; }
    }
}