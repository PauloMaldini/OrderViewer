namespace OrderViewer.API.Models.OrderItem.Base
{
    public abstract class OrderItemDtoBase
    {
        public long ProductId { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal Price { get; set; }
    }
}