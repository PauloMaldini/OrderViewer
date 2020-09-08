using AutoMapper;
using OrderViewer.API.Models.OrderItem;
using OrderViewer.API.Models.OrderItem.Base;
using OrderViewer.Core.Entities;

namespace OrderViewer.API.Profiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(x => x.ProductName,
                    y => y.MapFrom(
                        z => z.Product.Name))
                .ForMember(x => x.Price,
                    y => y.MapFrom(
                        z => z.Product.Price));
            
            CreateMap<OrderItemDtoBase, OrderItem>()
                .Include<OrderItemForUpdatingDto, OrderItem>()
                .Include<OrderItemForCreatingDto, OrderItem>()
                .ForMember(x => x.ProductRefId,
                    y => y.MapFrom(
                        z => z.ProductId));

            CreateMap<OrderItemForCreatingDto, OrderItem>()
                .ForMember(x => x.OrderRefId,
                    y => y.MapFrom(
                        z => z.OrderId));

            CreateMap<OrderItemForUpdatingDto, OrderItem>();
        }
    }
}