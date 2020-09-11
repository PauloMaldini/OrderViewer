using System;
using System.Collections.Generic;
using OrderViewer.Core.Base;
using OrderViewer.Core.Concrete;
using OrderViewer.Core.Contexts;

namespace OrderViewer.Core.Entities
{
    public class Product : EntityCatalogBase<long>
    {
        public double Price { get; set; }  
        
        public List<OrderItem> OrderItems { get; set; }
    }
    
    public class ProductFilter : FilterBase
    {
    
    }

    public class ProductRepository : EFGenericRepositoryBase<Product, ProductFilter, long>
    {
        public ProductRepository(OrderViewerContext context) : base(context)
        {
        
        }
    }
}