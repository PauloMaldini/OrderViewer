using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrderViewer.Core.Interfaces;

namespace OrderViewer.API.Base
{
    public abstract class CrudControllerAsyncBase<TEntity, 
                                                  TFilter, 
                                                  TKey, 
                                                  TEntityDto,
                                                  TEntityForCreationDto,
                                                  TEntityForUpdatingDto,
                                                  TFilterDto> : ApiControllerBase
        where TFilter : IFilter
        where TFilterDto: IFilter
        where TEntity: IEntity<TKey>
    {
        protected readonly IRepository<TEntity, TFilter, TKey> Repository;
        protected readonly IMapper Mapper; 

        protected CrudControllerAsyncBase(IRepository<TEntity, TFilter, TKey> repository,
            IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        [HttpPost]
        public virtual async Task<ActionResult<TEntityDto>> CreateAsync(TEntityForCreationDto entityForCreationDto)
        {
            var entity = Mapper.Map<TEntity>(entityForCreationDto);
            Repository.Create(entity);
            await Repository.SaveAsync();

            return CreatedAtRoute("ReadEntity", new { id = entity.Id }, entity);
        }

        [HttpGet("{id}", Name = "ReadEntity")]
        public virtual async Task<ActionResult<TEntity>> ReadAsync(TKey id)
        {
            var result = await Repository.ReadAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(result);
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntityDto>>> ReadAsync([FromQuery]TFilterDto filter)
        {
            var selection = await Repository.ReadAsync(Mapper.Map<TFilter>(filter));
            Response.Headers["TotalCount"] = selection.TotalCount.ToString();
            Response.Headers["FilteredCount"] = selection.FilteredCount.ToString();
            
            return Ok(selection.Items);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> UpdateAsync(TKey id, TEntityForUpdatingDto entityDto)
        {
            var entity = await Repository.ReadAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            Mapper.Map(entityDto, entity);
            Repository.Update(entity);
            await Repository.SaveAsync();
            
            return NoContent();
        }

        [HttpDelete]
        public virtual async Task<ActionResult> DeleteAsync(TKey id)
        {
            var entity = await Repository.ReadAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            
            Repository.Delete(entity);
            await Repository.SaveAsync();
            
            return Ok();
        }
        
        public override ActionResult ValidationProblem(
            [ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}
