using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using X.PagedList;

namespace FahasaStoreAPI.Base.Implementations
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TCreateDto, TEditDto, TKey> : ControllerBase
        where TEntity : class
        where TCreateDto : class
        where TEditDto : class
        where TKey : IEquatable<TKey>
    {
        protected readonly IBaseService<TEntity, TCreateDto, TEditDto, TKey> _service;

        public BaseController(IBaseService<TEntity, TCreateDto, TEditDto, TKey> service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult> Details(TKey id)
        {
            var entity = await _service.FindByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost("DetailsHaveList/{id}")]
        public virtual async Task<ActionResult<TEntity>> DetailsHaveList(TKey id, List<AttributeCollection> attributeCollection)
        {
            var entity = await _service.FindByIdHaveListAsync(id, attributeCollection);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TEntity>> Create(TCreateDto dto)
        {
            var entity = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Details), new { id = entity }, entity);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(TKey id, TEditDto dto)
        {
            var idProperty = typeof(TEditDto).GetProperty("Id");
            if (idProperty != null && !id.Equals(idProperty.GetValue(dto)))
            {
                return BadRequest();
            }

            var exists = await _service.ExistsAsync(id);
            if (!exists)
            {
                return NotFound();
            }

            var result = await _service.UpdateAsync(id, dto);
            
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(TKey id)
        {
            var entity = await _service.ExistsAsync(id);
            if (!entity)
            {
                return NotFound();
            }

            var result = await _service.DeleteAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        //[HttpPost("filter")]
        //public virtual async Task<ActionResult<FilterVM<TEntity>>> Filter(FilterOptions filterOptions)
        //{
        //    var result = await _service.FilterAsync(filterOptions);
        //    return Ok(result);
        //}

        //[HttpGet("filter")]
        //public virtual async Task<ActionResult<FilterVM<TEntity>>> FilterGet([FromQuery] FilterOptions filterOptions)
        //{
        //    var result = await _service.FilterAsync(filterOptions);
        //    return Ok(result);
        //}

        [HttpPost("Filter")]
        public virtual async Task<ActionResult> Filter(FilterOptions filterOptions)
        {
            var result = await _service.FilterAsync(filterOptions);
            return Ok(result);
        }
    }

}
