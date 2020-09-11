using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.Base;
using OrderViewer.Core.Concrete;
using OrderViewer.Core.Contexts;
using OrderViewer.Core.Entities;
using OrderViewer.Core.Enums;

namespace OrderViewer.Core.Reports
{
    public class OrderSummary 
    {
        public long Number { get; set; }
        
        public DateTime Date { get; set; }
        
        public OrderStatus Status { get; set; }
        
        public double TotalPrice { get; set; }
        
        public double TotalProductPrice { get; set; }
        
        public int TotalQuantity { get; set; }
        
        public List<OrderSummaryItem> Items { get; set; }

        public object Data { get; set; }
    }

    public class OrderSummaryItem
    {
        public long Number { get; set; }
        
        public string ProductName { get; set; }
        
        public int Quantity { get; set; }
        
        public double Price { get; set; }
        
        public double TotalPrice { get; set; } 
    }

    public class OrderSummaryFilter : FilterBase
    {
        
    }

    //TODO Отчет написать в виде одного запроса. Сейчас стоит костыль на двух запросах, т.к. EF не компилирует в SQL то, что я написал в виде одного запроса (одна его часть закомментирована)
    public class OrderSummaryReport : OrderViewerReportBase
    {
        public OrderSummaryReport(OrderViewerContext context) : base(context)
        {
            
        }

        public override async Task<Selection<OrderSummary>> ReadAsync(OrderSummaryFilter filter)
        {
            var orderSummary = (await InitQuery(filter).ToListAsync()).First();
            orderSummary.Items = await Context.OrderItems
                .Include(x => x.Product)
                .Where(x => x.OrderRefId == filter.Id)
                .Select(x => new OrderSummaryItem
                {
                    Number = x.Product.Id,
                    ProductName = x.Product.Name,
                    Price = x.Product.Price,
                    Quantity = x.Quantity,
                    TotalPrice = x.Product.Price * x.Quantity
                }).ToListAsync();

            return new Selection<OrderSummary>()
            {
                TotalCount = 1,
                FilteredCount = 1,
                Items = new List<OrderSummary> {orderSummary}
            };
        }

        protected override IQueryable<OrderSummary> InitQuery(OrderSummaryFilter filter)
        {
            var query = from o in Context.Orders
                join oi in Context.OrderItems on o.Id equals oi.OrderRefId
                join p in Context.Products on oi.ProductRefId equals p.Id
                where o.Id == filter.Id
                group new {o, oi, p} by new {o.Id, o.Timestamp, o.OrderStatus}
                into g
                select new OrderSummary
                {
                    Number = g.Key.Id,
                    Date = g.Key.Timestamp,
                    Status = g.Key.OrderStatus,
                    TotalPrice = g.Sum(x => x.oi.Quantity * x.p.Price),
                    TotalProductPrice = g.Sum(x => x.p.Price),
                    TotalQuantity = g.Sum(x => x.oi.Quantity),
                    #region [ Закомментировано, т.к. EF в рантайме не хочет компилировать запрос вместе с этой частью. Нужно в целом переписать запрос ]
                    // Items = g.Select(x => new OrderSummaryItem
                    // {
                    //     ProductName = x.p.Name,
                    //     Price = x.p.Price,
                    //     Quantity = x.oi.Quantity,
                    //     TotalPrice = x.p.Price * x.oi.Quantity
                    // }).ToList()
                    #endregion
                };
            
            return query;
        }

        protected override IQueryable<OrderSummary> AddFilter(IQueryable<OrderSummary> query, OrderSummaryFilter filter)
        {
            return query;
        }
    } 
}