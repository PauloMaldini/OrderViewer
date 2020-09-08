using AutoMapper;
using OrderViewer.API.Models.Order;
using OrderViewer.Core.Entities;

namespace OrderViewer.API.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            
            CreateMap<OrderFilterDto, OrderFilter>();
            CreateMap<OrderForCreatingDto, Order>();
            CreateMap<OrderForUpdatingDto, Order>();
        }    
    }
}