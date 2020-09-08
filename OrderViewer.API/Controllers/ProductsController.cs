using AutoMapper;
using OrderViewer.API.Base;
using OrderViewer.API.Models.Product;
using OrderViewer.Core.Entities;
using OrderViewer.Core.Interfaces;
using ProductFilter = OrderViewer.Core.Entities.ProductFilter;

namespace OrderViewer.API.Controllers
{
    public class ProductsController : CrudControllerAsyncBase<Product,
        ProductFilter, long, ProductDto, ProductForCreatingDto, ProductForUpdatingDto, ProductFilterDto>
    {
        public ProductsController(IRepository<Product, ProductFilter, long> repository, 
            IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }

}