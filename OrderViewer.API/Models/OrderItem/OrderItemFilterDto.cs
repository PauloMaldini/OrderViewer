using OrderViewer.Core.Base;

namespace OrderViewer.API.Models.OrderItem
{
    public class OrderItemFilterDto : FilterBase
    {
        public long? OrderId { get; set; }
    }
}