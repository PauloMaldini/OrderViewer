using AutoMapper;
using OrderViewer.API.Base;
using OrderViewer.API.Models.OrderItem;
using OrderViewer.Core.Entities;
using OrderViewer.Core.Interfaces;

namespace OrderViewer.API.Controllers
{
    public class OrderItemsController : CrudControllerAsyncBase<OrderItem,
            OrderItemFilter, long, OrderItemDto, OrderItemForCreatingDto, OrderItemForUpdatingDto, OrderItemFilterDto>
    {
        public OrderItemsController(IRepository<OrderItem, OrderItemFilter, long> repository, 
            IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}