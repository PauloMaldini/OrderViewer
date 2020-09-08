using AutoMapper;
using OrderViewer.API.Models.OrderSummary;
using OrderViewer.Core.Reports;

namespace OrderViewer.API.Profiles
{
    public class OrderSummaryProfile : Profile
    {
        public OrderSummaryProfile()
        {
            CreateMap<OrderSummary, OrderSummaryDto>();
            CreateMap<OrderSummaryFilter, OrderSummary>();
        }
    }
}