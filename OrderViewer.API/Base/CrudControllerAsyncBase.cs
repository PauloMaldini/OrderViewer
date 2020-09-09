using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrderViewer.API.Attributes;
using OrderViewer.Core.Interfaces;

namespace OrderViewer.API.Base
{
    public abstract class CrudControllerAsyncBase<TEntity, 
                                                  TFilter, 
                                                  TKey, 
                                                  TEntityDto,
                                                  TEntityForCreatingDto,
                                                  TEntityForUpdatingDto,
                                                  TFilterDto> : ApiControllerBase
        where TFilter : IFilter
        where TEntityForUpdatingDto: class
    {
        protected readonly IRepository<TEntity, TFilter, TKey> Repository;

        protected CrudControllerAsyncBase(IRepository<TEntity, TFilter, TKey> repository,
            IMapper mapper) : base(mapper)
        {
            Repository = repository;
        }

        [HttpPost]
        public virtual async Task<ActionResult<TEntityDto>> Create(TEntityForCreatingDto entityForCreationDto)
        {
            var entity = Mapper.Map<TEntity>(entityForCreationDto);
            Repository.Create(entity);
            await Repository.SaveAsync();

            return CreatedAtRoute("ReadEntity", new { id = GetEntityId(entity) }, entity);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntityDto>> Read(TKey id)
        {
            var result = await Repository.ReadAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(Mapper.Map<TEntityDto>(result));
        }

        [HttpGet]
        [ResponseHeader("Total-Count", typeof(long))]
        [ResponseHeader("Filtered-Count", typeof(long))]
        public virtual async Task<ActionResult<IEnumerable<TEntityDto>>> Read([FromQuery]TFilterDto filter)
        {
            var page = await Repository.ReadAsync(Mapper.Map<TFilter>(filter));
            Response.Headers["Total-Count"] = page.TotalCount.ToString();
            Response.Headers["Filtered-Count"] = page.FilteredCount.ToString();
            
            return Ok(Mapper.Map<List<TEntityDto>>(page.Items)); 
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update(TKey id, TEntityForUpdatingDto entityDto)
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
        
        [HttpPatch("{id}")]
        public virtual async Task<ActionResult> Update(TKey id, JsonPatchDocument<TEntityForUpdatingDto> patchDocument)
        {
            var entity = await Repository.ReadAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            var entityForUpdatingDto = Mapper.Map<TEntityForUpdatingDto>(entity);
            patchDocument.ApplyTo(entityForUpdatingDto, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
            if (!TryValidateModel(entityForUpdatingDto))
            {
                return ValidationProblem(ModelState); //TODO Баг: дает 400 ошибку вместо 422
            }

            Mapper.Map(entityForUpdatingDto, entity);
            Repository.Update(entity);
            await Repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete]
        public virtual async Task<ActionResult> Delete(TKey id)
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
        
        protected virtual TKey GetEntityId(TEntity entity)
        {
            var keyProp = entity.GetType().GetProperty("Id");
            if (keyProp == null || keyProp.GetType() != typeof(TKey))
            {
                throw new InvalidOperationException("Класс сущности должен содержать поле Id"); 
            }

            return (TKey)keyProp.GetValue(entity);
        }
    }
}
