namespace OrderViewer.API.Models.OrderItem
{
    public class OrderItemForCreatingDto
    {
        public long OrderId { get; set; }
        
        public long ProductId { get; set; }
        
        public int Quantity { get; set; }
    }
}