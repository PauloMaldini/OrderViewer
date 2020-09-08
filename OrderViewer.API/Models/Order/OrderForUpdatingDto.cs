using OrderViewer.Core.Enums;

namespace OrderViewer.API.Models.Order
{
    public class OrderForUpdatingDto
    {
        public OrderState OrderState { get; set; }
    }
}