using AutoMapper;
using OrderViewer.API.Models.OrderSummary;
using OrderViewer.Core.Concrete;
using OrderViewer.Core.Reports;

namespace OrderViewer.API.Profiles
{
    public class OrderSummaryProfile : Profile
    {
        public OrderSummaryProfile()
        {
            CreateMap<OrderSummaryItem, OrderSummaryItemDto>();
            CreateMap<OrderSummary, OrderSummaryDto>();
            CreateMap<OrderSummaryFilterDto, OrderSummaryFilter>()
                .ForMember(x => x.Id,
                    y => y.MapFrom(
                        z => z.OrderId));

            CreateMap<Selection<OrderSummary>, Selection<OrderSummaryDto>>();
        }
    }
}