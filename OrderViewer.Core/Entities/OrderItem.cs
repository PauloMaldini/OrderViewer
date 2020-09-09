using System.ComponentModel.DataAnnotations.Schema;
using OrderViewer.Core.Base;
using OrderViewer.Core.Concrete;
using OrderViewer.Core.Contexts;

namespace OrderViewer.Core.Entities
{
    public class OrderItem : EntityBase<long>
    {
        [ForeignKey("Order")]
        public long OrderRefId { get; set; }
        public Order Order { get; set; }
        
        [ForeignKey("Product")]
        public long ProductRefId { get; set; }
        public Product Product { get; set; }
        
        public int Quantity { get; set; }
    }
    
    public class OrderItemFilter : FilterBase
    {
    
    }

    public class OrderItemRepository : EFGenericRepositoryBase<OrderItem, OrderItemFilter, long>
    {
        public OrderItemRepository(OrderViewerContext context) : base(context)
        {
            
        }
    }

}