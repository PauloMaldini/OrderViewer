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

    public class OrderRepositoryBase : EFGenericRepositoryBase<Order, OrderFilter, long>
    {
        public OrderRepositoryBase(OrderViewerContext context) : base(context)
        {
            
        }
    }
}