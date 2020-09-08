using OrderViewer.Core.Contexts;
using OrderViewer.Core.Reports;

namespace OrderViewer.Core.Base
{
    public abstract class OrderViewerReportBase : EFReportBase<OrderSummary, OrderSummaryFilter>
    {
        protected readonly OrderViewerContext Context;
        
        protected OrderViewerReportBase(OrderViewerContext context)
        {
            Context = context;
        }
    }
}