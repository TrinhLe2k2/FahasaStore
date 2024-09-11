using FahasaStore.Models.Interfaces;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Base.Implementations
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity, TViewModel> : ControllerBase
        where TEntity : class
        where TViewModel : class, IEntity
    {
        protected readonly IBaseService<TEntity, TViewModel> _service;

        public BaseController(IBaseService<TEntity, TViewModel> service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult> Details(int id)
        {
            var entity = await _service.FindByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost("Filter")]
        public virtual async Task<ActionResult> Filter(FilterOptions filterOptions)
        {
            var result = await _service.FilterAsync(filterOptions);
            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TEntity>> Create(TViewModel model)
        {
            var entity = await _service.AddAsync(model);
            return CreatedAtAction(nameof(Details), new { id = entity }, entity);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id, TViewModel model)
        {
            var result = await _service.UpdateAsync(id, model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
