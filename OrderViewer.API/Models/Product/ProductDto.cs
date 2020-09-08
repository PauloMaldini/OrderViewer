using System;
using OrderViewer.API.Models.Product.Base;

namespace OrderViewer.API.Models.Product
{
    public class ProductDto : ProductDtoBase
    {
        public long Id { get; set; }
    }
}