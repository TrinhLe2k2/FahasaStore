using FahasaStore.Models.Interfaces;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Areas.Base
{
    [Authorize(AppRole.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminBaseController<TEntity, TDetail, TExtend, TBase> : ControllerBase
        where TEntity : class
        where TDetail : class, TExtend
        where TExtend : class, TBase
        where TBase : class, IEntity
    {
        protected readonly IAdminBaseService<TEntity, TDetail, TExtend, TBase> _adminBaseService;

        public AdminBaseController(IAdminBaseService<TEntity, TDetail, TExtend, TBase> adminBaseService)
        {
            _adminBaseService = adminBaseService;
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var result = await _adminBaseService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [RequestSizeLimit(10_000_000)]
        public virtual async Task<IActionResult> Add(TBase model)
        {
            var result = await _adminBaseService.AddAsync(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [RequestSizeLimit(10_000_000)]
        public virtual async Task<IActionResult> Update(int id, TBase model)
        {
            if (!model.Id.Equals(id)) return BadRequest();

            var result = await _adminBaseService.UpdateAsync(id, model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var result = await _adminBaseService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPost("Filter")]
        public virtual async Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            var result = await _adminBaseService.FilterAsync(filterOptions);
            return Ok(result);
        }
    }
}
