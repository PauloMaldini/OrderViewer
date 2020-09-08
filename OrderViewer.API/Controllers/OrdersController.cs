using AutoMapper;
using OrderViewer.API.Base;
using OrderViewer.API.Models.Order;
using OrderViewer.Core.Entities;
using OrderViewer.Core.Interfaces;

namespace OrderViewer.API.Controllers
{
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