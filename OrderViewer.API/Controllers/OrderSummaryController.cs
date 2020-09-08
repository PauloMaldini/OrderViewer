using AutoMapper;
using OrderViewer.API.Base;
using OrderViewer.API.Models.OrderSummary;
using OrderViewer.Core.Interfaces;
using OrderViewer.Core.Reports;

namespace OrderViewer.API.Controllers
{
    public class OrderSummaryController : ReportControllerAsyncBase<OrderSummary, 
        OrderSummaryFilter, OrderSummaryDto, OrderSummaryFilterDto>
    {
        public OrderSummaryController(IReadCollection<OrderSummary, OrderSummaryFilter> repository, 
            IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}