using OrderViewer.Core.Enums;

namespace OrderViewer.API.Models.Order
{
    public class OrderForUpdatingDto
    {
        public OrderStatus OrderStatus { get; set; }
    }
}