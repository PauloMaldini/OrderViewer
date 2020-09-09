using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderViewer.API.Base;
using OrderViewer.API.Models.Order;
using OrderViewer.Core.Entities;
using OrderViewer.Core.Interfaces;

namespace OrderViewer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json", "application/xml")]
    public class OrdersController : CrudControllerAsyncBase<Order,
        OrderFilter, long, OrderDto, OrderForCreatingDto, OrderForUpdatingDto, OrderFilterDto>
    {
        public OrdersController(IRepository<Order, OrderFilter, long> repository, 
            IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}