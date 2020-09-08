using System.Linq;
using OrderViewer.Core.Base;
using OrderViewer.Core.Context;

namespace OrderViewer.Core.Reports
{
    public class OrderSummary 
    {
        
    }

    public class OrderSummaryFilter : FilterBase
    {
        
    }

    public class OrderSummaryReport : EFReportBase<OrderSummary, OrderSummaryFilter>
    {
        public OrderSummaryReport(OrderViewerContext context) 
        {
            
        }

        protected override IQueryable<OrderSummary> InitQuery(OrderSummaryFilter filter)
        {
            throw new System.NotImplementedException();
        }

        protected override IQueryable<OrderSummary> AddFilter(IQueryable<OrderSummary> query, OrderSummaryFilter filter)
        {
            throw new System.NotImplementedException();
        }
    } 
}