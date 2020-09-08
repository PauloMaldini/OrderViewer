using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.Concrete;
using OrderViewer.Core.Interfaces;

namespace OrderViewer.Core.Base
{
    public abstract class EFReportBase<TEntity, TFilter> : IReadCollection<TEntity, TFilter>
        where TFilter : IPagination
    {
        protected  IQueryable<TEntity> Query { get; set; }

        public Selection<TEntity> Read(TFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Selection<TEntity>> ReadAsync(TFilter filter)
        {
            Query = InitQuery(filter);

            var totalCount = await Query.CountAsync();
            var entities = AddFilter(Query, filter);
            var filteredCount = await entities.CountAsync();
                
            var items = filter.PageIndex == null ? entities
                        : entities.Skip((int)(filter.PageIndex * filter.PageSize))
                                  .Take((int)filter.PageSize);

            return new Selection<TEntity>
            {
                Items = await items.ToListAsync(),
                FilteredCount = filteredCount,
                TotalCount = totalCount
            };
        }

        protected abstract IQueryable<TEntity> InitQuery(TFilter filter);

        protected abstract IQueryable<TEntity> AddFilter(IQueryable<TEntity> query,
                                                         TFilter filter);
    }
}
