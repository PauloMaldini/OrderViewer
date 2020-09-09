using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderViewer.API.Base;
using OrderViewer.API.Models.OrderSummary;
using OrderViewer.Core.Interfaces;
using OrderViewer.Core.Reports;

namespace OrderViewer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json", "application/xml")]
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