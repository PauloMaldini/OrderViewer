using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.Base;
using OrderViewer.Core.Contexts;
using OrderViewer.Core.Entities;
using OrderViewer.Core.Enums;

namespace OrderViewer.Core.Reports
{
    public class OrderSummary 
    {
        public string Number { get; set; }
        
        public DateTime Date { get; set; }
        
        public OrderStatus Status { get; set; }
        
        public string StatusName { get; set; }
        
        public decimal TotalPrice { get; set; }
        
        public decimal TotalProductPrice { get; set; }
        
        public int TotalQuantity { get; set; }
        
        public List<OrderSummaryItem> Items { get; set; }
    }

    public class OrderSummaryItem
    {
        public string ProductName { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal Price { get; set; }
        
        public decimal TotalPrice { get; set; } 
    }

    public class OrderSummaryFilter : FilterBase
    {
        
    }

    public class OrderSummaryReport : OrderViewerReportBase
    {
        public OrderSummaryReport(OrderViewerContext context) : base(context)
        {
            
        }

        protected override IQueryable<OrderSummary> InitQuery(OrderSummaryFilter filter)
        {
            var q = Context.OrderItems
                .Include(x => x.Order)
                .Include(x => x.Product)
                .GroupBy(x => new {x.Order.Id, x.Order.Timestamp, x.Order.OrderStatus}, (x, y) =>
                    new OrderSummary
                    {
                        //Number = string.Format("Order #{1}", x.Id),
                        Date = x.Timestamp,
                        Status = x.OrderStatus,
                        //StateName = x.OrderStatus.ToString(),
                    });
                

            return q;
            
            
            var query = from o in Context.Orders
                //join oi in Context.Set<OrderItem>() on o.Id equals oi.OrderRefId
                //join p in Context.Set<Product>() on oi.ProductRefId equals p.Id
                group o//new {o.Id, o.Timestamp, o.OrderStatus/*, oi.Quantity, p.Price, p.Name*/}
                    by o.Id//new {o.Id, o.Timestamp, o.OrderStatus}
                into g
                select new OrderSummary
                {
                    Number = $"Order #{g.Key}",
                    // Date = g.Key.Timestamp,
                    // Status = g.Key.OrderStatus,
                    // StateName = g.Key.OrderStatus.ToString(),
                    //TotalPrice = g.Sum(x => x.Quantity * x.Price),
                    //TotalProductPrice = g.Sum(x => x.Price), 
                    //TotalQuantity = g.Sum(x => x.Quantity),
                    // Items = (from oi in Context.OrderItems
                    //     join p in Context.Products on oi.ProductRefId equals p.Id
                    //     where oi.OrderRefId == g.Key.Id
                    //     select new OrderSummaryItem
                    //     {
                    //         ProductName = p.Name,
                    //         Price = p.Price,
                    //         Quantity = oi.Quantity,
                    //         TotalPrice = p.Price * oi.Quantity
                    //     }).ToList()
                };
            
            return query;
        }

        protected override IQueryable<OrderSummary> AddFilter(IQueryable<OrderSummary> query, OrderSummaryFilter filter)
        {
            return query;
        }
    } 
}