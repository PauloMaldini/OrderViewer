using System;
using OrderViewer.Core.Base;
using OrderViewer.Core.Enums;

namespace OrderViewer.Core.Entities
{
    public class Order : EntityBase<long>
    {
        public OrderState OrderState { get; set; }
        
        public DateTime Timestamp { get; set; }
    }
}