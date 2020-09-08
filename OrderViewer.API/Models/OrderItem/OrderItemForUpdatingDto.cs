namespace OrderViewer.API.Models.OrderItem
{
    public class OrderItemForUpdatingDto
    {
        public long OrderItemId { get; set; }
        
        public long ProductId { get; set; }
        
        public int Quantity { get; set; }
    }
}