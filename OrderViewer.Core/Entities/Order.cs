using System;
using OrderViewer.Core.Base;
using OrderViewer.Core.Concrete;
using OrderViewer.Core.Context;
using OrderViewer.Core.Enums;

namespace OrderViewer.Core.Entities
{
    public class Order : EntityBase<long>
    {
        public OrderState OrderState { get; set; }
        
        public DateTime Timestamp { get; set; }
    }

    public class OrderFilter : FilterBase
    {
        
    }

    public class OrderRepository : EFGenericRepository<Order, OrderFilter, long>
    {
        public OrderRepository(OrderViewerContext context) : base(context)
        {
            
        }
    }
}