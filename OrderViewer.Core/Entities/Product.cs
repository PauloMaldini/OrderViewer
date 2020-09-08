using System;
using OrderViewer.Core.Base;
using OrderViewer.Core.Concrete;
using OrderViewer.Core.Contexts;

namespace OrderViewer.Core.Entities
{
    public class Product : EntityCatalogBase<long>
    {
        public Decimal Price { get; set; }                                                                        
    }
    
    public class ProductFilter : FilterBase
    {
    
    }

    public class ProductRepositoryBase : EFGenericRepositoryBase<Product, ProductFilter, long>
    {
        public ProductRepositoryBase(OrderViewerContext context) : base(context)
        {
        
        }
    }
}