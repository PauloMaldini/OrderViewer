using System.ComponentModel.DataAnnotations;
using OrderViewer.Core.Interfaces;

namespace OrderViewer.Core.Base
{
    public abstract class FilterBase : IFilter
    {
        public long? Id { get; set; }
        
        [Range(0, long.MaxValue)]
        public long? PageIndex { get; set; }

        [Range(1, long.MaxValue)]
        public long? PageSize { get; set; }
        
        public string OrderBy { get; set; }
    }
}
