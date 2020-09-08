using System.ComponentModel.DataAnnotations.Schema;
using OrderViewer.Core.Base;

namespace OrderViewer.Core.Entities
{
    public class OrderItem : EntityBase<long>
    {
        [ForeignKey("Order")]
        public long OrderRefId { get; set; }
        public Order Order { get; set; }
        
        
    }
}