using FahasaStore.Models.Interfaces;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FahasaStoreAPI.Areas.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerBaseController<TEntity, TDetail, TExtend, TBase> : ControllerBase
        where TEntity : class
        where TDetail : class, TExtend
        where TExtend : class, TBase
        where TBase : class, IEntity, IUserModel
    {
        protected readonly ICustomerBaseService<TEntity, TDetail, TExtend, TBase> _customerBaseService;

        public CustomerBaseController(ICustomerBaseService<TEntity, TDetail, TExtend, TBase> customerBaseService)
        {
            _customerBaseService = customerBaseService;
        }

        [Authorize(AppRole.Customer)]
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var userId = User.FindFirst(c => c.Type == "UserId")?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var result = await _customerBaseService.GetByIdAsync(id, int.Parse(userId));
            return Ok(result);
        }

        [Authorize(AppRole.Customer)]
        [HttpPost]
        public virtual async Task<IActionResult> Add(TBase model)
        {
            var userId = User.FindFirst(c => c.Type == "UserId")?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var result = await _customerBaseService.AddAsync(model, int.Parse(userId));
            return Ok(result);
        }

        [Authorize(AppRole.Customer)]
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id, TBase model)
        {
            var userId = User.FindFirst(c => c.Type == "UserId")?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            if (!model.Id.Equals(id) || !model.UserId.Equals(int.Parse(userId))) return BadRequest();

            var result = await _customerBaseService.UpdateAsync(id, model, int.Parse(userId));
            return Ok(result);
        }

        [Authorize(AppRole.Customer)]
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirst(c => c.Type == "UserId")?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var result = await _customerBaseService.DeleteAsync(id, int.Parse(userId));
            return Ok(result);
        }

        [Authorize(AppRole.Customer)]
        [HttpPost("Filter")]
        public virtual async Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            var userId = User.FindFirst(c => c.Type == "UserId")?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var result = await _customerBaseService.FilterAsync(filterOptions, int.Parse(userId));
            return Ok(result);
        }

    }
}
