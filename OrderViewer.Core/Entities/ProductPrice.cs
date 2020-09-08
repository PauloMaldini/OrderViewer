using System;
using System.ComponentModel.DataAnnotations.Schema;
using OrderViewer.Core.Base;
using OrderViewer.Core.Concrete;
using OrderViewer.Core.Context;

namespace OrderViewer.Core.Entities
{
    public class ProductPrice : EntityBase<long>
    {
        public DateTime Timestamp { get; set; }
        
        public decimal Price { get; set; }
        
        [ForeignKey("Product")]
        public long ProductRefId { get; set; }
        public Product Product { get; set; }
    }
    
    public class ProductPriceFilter : FilterBase
    {
        
    }

    public class ProductPriceRepository : EFGenericRepository<ProductPrice, ProductPriceFilter, long>
    {
        public ProductPriceRepository(OrderViewerContext context) : base(context)
        {
                                
        }
    }
}