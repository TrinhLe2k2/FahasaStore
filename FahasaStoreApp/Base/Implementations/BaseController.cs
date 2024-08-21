using AutoMapper;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.Interfaces;
using FahasaStoreApp.Base.Interfaces;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FahasaStoreApp.Base.Implementations
{
    public class BaseController<TEntity, TCreateDto, TEditDto, TKey> : Controller
        where TEntity : class, IEntity<TKey>
        where TCreateDto : class
        where TEditDto : class
        where TKey : IEquatable<TKey>
    {
        protected readonly IBaseService<TEntity, TCreateDto, TEditDto, TKey> _service;

        public BaseController(IBaseService<TEntity, TCreateDto, TEditDto, TKey> service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> Index(FilterOptions filterOptions)
        {
            if (TempData["FilterResult"] != null)
            {
                var filterResult = JsonConvert.DeserializeObject<FilterVM<Category>>(TempData["FilterResult"]?.ToString() ?? "");
                return View(filterResult);
            }
            return View(await _service.Filter(filterOptions));
        }

        [HttpPost, ActionName("Index")]
        public virtual async Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            var filterResult = await _service.Filter(filterOptions);
            TempData["FilterResult"] = JsonConvert.SerializeObject(filterResult);
            return RedirectToAction("Index");
        }

        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(TCreateDto model)
        {
            TEntity createdEntity = await _service.CreateAsync(model);
            return RedirectToAction("Details", new { id = createdEntity.Id });
        }

        public virtual async Task<IActionResult> Details(TKey id)
        {
            var entity = await _service.Details(id);
            return View(entity);
        }

        public virtual async Task<IActionResult> Edit(TKey id)
        {
            var entity = await _service.Details(id);
            //var model = _mapper.Map<TEditDto>(entity);
            return View(entity);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Edit(TKey id, TEditDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var updatedEntity = await _service.Update(id, model);
            return RedirectToAction("Details", new { id = updatedEntity.Id });
        }

        public virtual async Task<IActionResult> Delete(TKey id)
        {
            var entity = await _service.Details(id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        public virtual async Task<IActionResult> DeleteConfirmed(TKey id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
