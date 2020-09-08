using System;

namespace OrderViewer.API.Models.Product.Base
{
    public abstract class ProductDtoBase
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public Decimal Price { get; set; }
    }
}