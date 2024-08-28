using AutoMapper;
using FahasaStoreApp.Base.Interfaces;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.Interfaces;
using FahasaStoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FahasaStoreApp.Base.Implementations
{
    public class BaseController<TEntity, TViewModel> : Controller
        where TEntity : class
        where TViewModel : class, IEntity<int>
    {
        protected readonly IBaseService<TEntity, TViewModel> _service;

        public BaseController(IBaseService<TEntity, TViewModel> service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> Index(FilterOptions filterOptions)
        {
            if (TempData["FilterResult"] != null)
            {
                var filterResult = JsonConvert.DeserializeObject<FilterVM<TViewModel>>(TempData["FilterResult"]?.ToString() ?? "");
                return View(filterResult);
            }
            return View(await _service.FilterAsync(filterOptions));
        }

        [HttpPost, ActionName("Index")]
        public virtual async Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            var filterResult = await _service.FilterAsync(filterOptions);
            TempData["FilterResult"] = JsonConvert.SerializeObject(filterResult);
            return RedirectToAction("Index");
        }

        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(TViewModel model)
        {
            var repository = await _service.CreateAsync(model);
            return RedirectToAction("Details", new { id = repository.Id });
        }

        public virtual async Task<IActionResult> Details(int id)
        {
            var repository = await _service.GetByIdAsync(id);
            return View(repository);
        }

        public virtual async Task<IActionResult> Edit(int id)
        {
            var repository = await _service.GetByIdAsync(id);
            return View(repository);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Edit(int id, TViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var repository = await _service.UpdateAsync(id, model);
            return RedirectToAction("Details", new { id = repository.Id });
        }

        public virtual async Task<IActionResult> Delete(int id)
        {
            var repository = await _service.GetByIdAsync(id);
            if (repository == null)
            {
                return NotFound();
            }
            return View(repository);
        }

        [HttpPost, ActionName("Delete")]
        public virtual async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
