using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderViewer.Core.Concrete;
using OrderViewer.Core.Interfaces;

namespace OrderViewer.API.Base
{
    public abstract class ReportControllerAsyncBase<TEntity, TFilter, TEntityDto, TFilterDto> : ApiControllerBase
       where TFilter : IFilter
    {
        protected readonly IReadCollection<TEntity, TFilter> Repository;

        protected ReportControllerAsyncBase(
            IReadCollection<TEntity, TFilter> repository, IMapper mapper) : base(mapper)
        {
            Repository = repository;
        }

        [HttpGet]
        public virtual async Task<ActionResult<Selection<TEntityDto>>> Read([FromQuery]TFilterDto filterDto)
        {
            var selection = await Repository.ReadAsync(Mapper.Map<TFilter>(filterDto));
            Response.Headers["Total-Count"] = selection.TotalCount.ToString();
            Response.Headers["Filtered-Count"] = selection.FilteredCount.ToString();
            
            return Ok(Mapper.Map<Selection<TEntityDto>>(selection));
        }
    }
}
