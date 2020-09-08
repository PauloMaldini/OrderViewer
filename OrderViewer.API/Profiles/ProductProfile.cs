using AutoMapper;
using OrderViewer.API.Models.Product;
using OrderViewer.Core.Entities;

namespace OrderViewer.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<ProductFilterDto, ProductFilter>();
            CreateMap<ProductForCreatingDto, Product>();
            CreateMap<ProductForUpdatingDto, Product>();
        }
    }
}