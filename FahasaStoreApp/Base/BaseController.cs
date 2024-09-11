using FahasaStore.Models.Interfaces;
using FahasaStoreApp.Models;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace FahasaStoreApp.Base
{
    public class BaseController<TEntity, TDetail, TExtend, TBase> : Controller
        where TEntity : class
        where TDetail : class, TExtend
        where TExtend : class, TBase
        where TBase : class, IEntity
    {
        protected readonly IBaseService<TEntity, TDetail, TExtend, TBase> _service;

        public BaseController(IBaseService<TEntity, TDetail, TExtend, TBase> service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> Index(FilterOptions filterOptions)
        {
            if (TempData["FilterResult"] != null)
            {
                var repository = JsonConvert.DeserializeObject<ApiResponse<FilterVM<TExtend>>>(TempData["FilterResult"]?.ToString() ?? "");

                if (repository != null && !repository.Error)
                {
                    return PartialView(repository.Data);
                }

                return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
            }
            var repository2 = await _service.FilterAsync(filterOptions);
            if (repository2 != null && !repository2.Error)
            {
                return PartialView(repository2.Data);
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
        }

        public virtual async Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            if (TempData["FilterResult"] != null)
            {
                var repository = JsonConvert.DeserializeObject<ApiResponse<FilterVM<TExtend>>>(TempData["FilterResult"]?.ToString() ?? "");

                if (repository != null && !repository.Error)
                {
                    return PartialView(repository.Data);
                }

                return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
            }
            var repository2 = await _service.FilterAsync(filterOptions);
            if (repository2 != null && !repository2.Error)
            {
                return PartialView(repository2.Data);
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
        }

        [HttpPost, ActionName("Filter")]
        public virtual async Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            var repository = await _service.FilterAsync(filterOptions);
            TempData["FilterResult"] = JsonConvert.SerializeObject(repository);
            return RedirectToAction("Filter");
        }

        public virtual async Task<IActionResult> Create(TBase model)
        {
            await Task.CompletedTask;
            return View(model);
        }

        [HttpPost, ActionName("Create")]
        public virtual async Task<IActionResult> CreateSubmit(TBase model)
        {
            if (!ModelState.IsValid)
            {
                await Create(model);
                return View(model);
            }
            var repository = await _service.AddAsync(model);
            if (repository != null && !repository.Error)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
        }

        public virtual async Task<IActionResult> Details(int id)
        {
            var repository = await _service.GetByIdAsync(id);
            if (repository != null && !repository.Error)
            {
                return View(repository.Data);
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
        }

        public virtual async Task<IActionResult> Edit(int id)
        {
            var repository = await _service.GetByIdAsync(id);
            if (repository != null && !repository.Error)
            {
                return View(repository.Data);
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
        }

        [HttpPost]
        public virtual async Task<IActionResult> Edit(int id, TBase model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var repository = await _service.UpdateAsync(id, model);

            if (repository != null && !repository.Error)
            {
                return RedirectToAction("Filter");
                //return RedirectToAction("Details", new { id });
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
        }

        public virtual async Task<IActionResult> Delete(int id)
        {
            var repository = await _service.GetByIdAsync(id);
            if (repository != null && !repository.Error)
            {
                return View(repository.Data);
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
        }

        [HttpPost, ActionName("Delete")]
        public virtual async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repository = await _service.DeleteAsync(id);
            if (repository != null && !repository.Error)
            {
                return RedirectToAction("Filter");
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            return View(errorViewModel);
        }
    }
}
