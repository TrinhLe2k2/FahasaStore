using FahasaStore.Models.Interfaces;
using FahasaStoreApp.Models;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace FahasaStoreApp.Areas.Base
{
    public class BaseController<TEntity, TDetail, TExtend, TBase> : Controller
        where TEntity : class
        where TDetail : class, TExtend
        where TExtend : class, TBase
        where TBase : class, IEntity
    {
        protected readonly IBaseService<TEntity, TDetail, TExtend, TBase> _serviceBase;

        public BaseController(IBaseService<TEntity, TDetail, TExtend, TBase> service)
        {
            _serviceBase = service;
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
            var repository2 = await _serviceBase.FilterAsync(filterOptions);
            if (repository2 != null && !repository2.Error)
            {
                return View(repository2.Data);
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
        }

        public virtual async Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            // Hạn chế sử dụng lưu trữ cookie, vì có thể gây ra lỗi 431, TempData["FilterResult"]
            if (TempData["FilterResult"] != null)
            {
                var repository = JsonConvert.DeserializeObject<ApiResponse<FilterVM<TExtend>>>(TempData["FilterResult"]?.ToString() ?? "");

                if (repository != null && !repository.Error)
                {
                    return PartialView(repository.Data);
                }

                return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
            }
            var repository2 = await _serviceBase.FilterAsync(filterOptions);
            if (repository2 != null && !repository2.Error)
            {
                return PartialView(repository2.Data);
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
        }

        [HttpPost, ActionName("Filter")]
        public virtual async Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            var repository = await _serviceBase.FilterAsync(filterOptions);
            var repositoryJson = JsonConvert.SerializeObject(repository);
            TempData["FilterResult"] = JsonConvert.SerializeObject(repository);
            return RedirectToAction("Filter");
        }

        public virtual async Task<IActionResult> Create()
        {
            await Task.CompletedTask;
            return PartialView();
        }

        [HttpPost, ActionName("Create")]
        public virtual async Task<IActionResult> CreateSubmit(TBase model)
        {
            if (!ModelState.IsValid)
            {
                await Create();
                return PartialView(model);
            }
            var repository = await _serviceBase.AddAsync(model);
            if (repository != null && !repository.Error)
            {
                //return RedirectToAction("Filter");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
        }

        public virtual async Task<IActionResult> Details(int id)
        {
            var repository = await _serviceBase.GetByIdAsync(id);
            if (repository != null && !repository.Error)
            {
                return PartialView(repository.Data);
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
        }

        public virtual async Task<IActionResult> Edit(int id)
        {
            var repository = await _serviceBase.GetByIdAsync(id);
            if (repository != null && !repository.Error)
            {
                return PartialView(repository.Data);
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
        }

        [HttpPost]
        public virtual async Task<IActionResult> Edit(int id, TBase model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(model);
            }

            var repository = await _serviceBase.UpdateAsync(id, model);

            if (repository != null && !repository.Error)
            {
                return RedirectToAction("Filter");
                //return RedirectToAction("Details", new { id });
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
        }

        public virtual async Task<IActionResult> Delete(int id)
        {
            var repository = await _serviceBase.GetByIdAsync(id);
            if (repository != null && !repository.Error)
            {
                return PartialView(repository.Data);
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
        }

        [HttpPost, ActionName("Delete")]
        public virtual async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repository = await _serviceBase.DeleteAsync(id);
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
