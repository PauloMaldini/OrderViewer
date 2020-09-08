using OrderViewer.Core.Base;
using OrderViewer.Core.Concrete;
using OrderViewer.Core.Context;

namespace OrderViewer.Core.Entities
{
    public class Product : EntityCatalogBase<long>
    {
                                                                        
    }
    
    public class ProductFilter : FilterBase
    {
    
    }

    public class ProductRepository : EFGenericRepository<Product, ProductFilter, long>
    {
        public ProductRepository(OrderViewerContext context) : base(context)
        {
        
        }
    }
}