using OrderViewer.API.Models.OrderItem.Base;

namespace OrderViewer.API.Models.OrderItem
{
    public class OrderItemForUpdatingDto : OrderItemDtoBase
    {
        public long Id { get; set; }
    }
}