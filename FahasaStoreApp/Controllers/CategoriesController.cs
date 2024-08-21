using AutoMapper;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreApp.Base.Implementations;
using FahasaStoreApp.Base.Interfaces;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.DTOs.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FahasaStoreApp.Controllers
{
    public class CategoriesController : BaseController<Category, CategoryCreateDto, CategoryEditDto, int>
    {
        public CategoriesController(IBaseService<Category, CategoryCreateDto, CategoryEditDto, int> service) : base(service)
        {
        }

        public override IActionResult Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> Create(CategoryCreateDto model)
        {
            return base.Create(model);
        }

        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        public override Task<IActionResult> DeleteConfirmed(int id)
        {
            return base.DeleteConfirmed(id);
        }

        public override Task<IActionResult> Details(int id)
        {
            return base.Details(id);
        }

        public override Task<IActionResult> Edit(int id)
        {
            return base.Edit(id);
        }

        public override Task<IActionResult> Edit(int id, CategoryEditDto model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override async Task<IActionResult> Index(FilterOptions filterOptions)
        {
            List<string> OrdersBy = new List<string> { "Id", "Name", "CreateAt" };
            ViewData["OrderBy"] = new SelectList(OrdersBy);
            if (filterOptions.Filters.Count == 0)
            {
                filterOptions.Filters.AddRange(new List<FilterItem>
                {
                    new FilterItem { Key = "Name", Value = "", TypeOfKey = "string", ComparisonOperator = "=" },
                    new FilterItem { Key = "Id", Value = "", TypeOfKey = "int", ComparisonOperator = "<=" }
                });
            }

            return await base.Index(filterOptions);
        }
    }
}
