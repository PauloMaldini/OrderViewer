using System;
using System.Collections.Generic;
using OrderViewer.Core.Base;
using OrderViewer.Core.Concrete;
using OrderViewer.Core.Contexts;
using OrderViewer.Core.Enums;

namespace OrderViewer.Core.Entities
{
    public class Order : EntityBase<long>
    {
        public OrderStatus OrderStatus { get; set; }
        
        public DateTime Timestamp { get; set; }
        
        public List<OrderItem> OrderItems { get; set; }
    }

    public class OrderFilter : FilterBase
    {
        
    }

    public class OrderRepository : EFGenericRepositoryBase<Order, OrderFilter, long>
    {
        public OrderRepository(OrderViewerContext context) : base(context)
        {
            
        }
    }
}