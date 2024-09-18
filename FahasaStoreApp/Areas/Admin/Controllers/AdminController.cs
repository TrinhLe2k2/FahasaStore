using FahasaStore.Models;
using FahasaStoreApp.Areas.Admin.Models;
using FahasaStoreApp.Areas.Admin.Services;
using FahasaStoreApp.Areas.Base;
using FahasaStoreApp.Constants;
using FahasaStoreApp.Models;
using FahasaStoreApp.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FahasaStoreApp.Areas.Admin.Controllers
{
    #region

    #region Address Ignore
    //[Authorize(Policy = AppRole.Admin)]
    //[Area("Admin")]
    //public class AdminAddressesController : BaseController<AdminAddresses, AddressDetail, AddressExtend, AddressBase>
    //{
    //    private readonly IAdminAddressService _service;

    //    public AdminAddressesController(IAdminAddressService service) : base(service)
    //    {
    //        _service = service;
    //    }

    //    public override Task<IActionResult> Create()
    //    {
    //        return base.Create();
    //    }

    //    public override Task<IActionResult> CreateSubmit(AddressBase model)
    //    {
    //        return base.CreateSubmit(model);
    //    }

    //    public override Task<IActionResult> Delete(int id)
    //    {
    //        return base.Delete(id);
    //    }

    //    public override Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        return base.DeleteConfirmed(id);
    //    }

    //    public override Task<IActionResult> Details(int id)
    //    {
    //        return base.Details(id);
    //    }

    //    public override Task<IActionResult> Edit(int id)
    //    {
    //        return base.Edit(id);
    //    }

    //    public override Task<IActionResult> Edit(int id, AddressBase model)
    //    {
    //        return base.Edit(id, model);
    //    }

    //    public override Task<IActionResult> Filter(FilterOptions filterOptions)
    //    {
    //        return base.Filter(filterOptions);
    //    }

    //    public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
    //    {
    //        return base.FilterSubmit(filterOptions);
    //    }

    //    public override Task<IActionResult> Index(FilterOptions filterOptions)
    //    {
    //        return base.Index(filterOptions);
    //    }
    //}
    #endregion

    #region AspNetUser Forbid
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminAspNetUsersController : BaseController<AdminAspNetUsers, AspNetUserDetail, AspNetUserExtend, AspNetUserBase>
    {
        private readonly IAdminAspNetUserService _service;

        public AdminAspNetUsersController(IAdminAspNetUserService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return Task.FromResult<IActionResult>(Forbid());
            //return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(AspNetUserBase model)
        {
            return Task.FromResult<IActionResult>(Forbid());
            //return base.CreateSubmit(model);
        }

        public override Task<IActionResult> Delete(int id)
        {
            return Task.FromResult<IActionResult>(Forbid());
            //return base.Delete(id);
        }

        public override Task<IActionResult> DeleteConfirmed(int id)
        {
            return Task.FromResult<IActionResult>(Forbid());
            //return base.DeleteConfirmed(id);
        }

        public override Task<IActionResult> Details(int id)
        {
            return Task.FromResult<IActionResult>(Forbid());
            //return base.Details(id);
        }

        public override Task<IActionResult> Edit(int id)
        {
            return Task.FromResult<IActionResult>(Forbid());
            //return base.Edit(id);
        }

        public override Task<IActionResult> Edit(int id, AspNetUserBase model)
        {
            return Task.FromResult<IActionResult>(Forbid());
            //return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region Author 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminAuthorsController : BaseController<AdminAuthors, AuthorDetail, AuthorExtend, AuthorBase>
    {
        private readonly IAdminAuthorService _service;

        public AdminAuthorsController(IAdminAuthorService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(AuthorBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, AuthorBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region Banner 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminBannersController : BaseController<AdminBanners, BannerDetail, BannerExtend, BannerBase>
    {
        private readonly IAdminBannerService _service;

        public AdminBannersController(IAdminBannerService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(BannerBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, BannerBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region Book 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminBooksController : BaseController<AdminBooks, BookDetail, BookExtend, BookBase>
    {
        private readonly IAdminBookService _service;
        private readonly IAdminSubcategoryService _subcategoryService;
        private readonly IAdminAuthorService _authorService;
        private readonly IAdminCoverTypeService _coverTypeService;
        private readonly IAdminDimensionService _dimensionService;

        public AdminBooksController(IAdminBookService service, IAdminSubcategoryService subcategoryService, IAdminAuthorService authorService, IAdminCoverTypeService coverTypeService, IAdminDimensionService dimensionService) : base(service)
        {
            _service = service;
            _subcategoryService = subcategoryService;
            _authorService = authorService;
            _coverTypeService = coverTypeService;
            _dimensionService = dimensionService;
        }

        public override async Task<IActionResult> Create()
        {
            var subcategories = await _subcategoryService.FilterAsync(new FilterOptions());
            ViewData["Subcategories"] = new SelectList(subcategories.Data?.Paged.Items, "Id", "Name");

            var authors = await _authorService.FilterAsync(new FilterOptions());
            ViewData["Authors"] = new SelectList(authors.Data?.Paged.Items, "Id", "Name");

            var coverTypes = await _coverTypeService.FilterAsync(new FilterOptions());
            ViewData["CoverTypes"] = new SelectList(coverTypes.Data?.Paged.Items, "Id", "TypeName");

            var dimensions = await _dimensionService.FilterAsync(new FilterOptions());
            var dimensionSelectList = dimensions.Data?.Paged.Items.Select(d => new
            {
                Id = d.Id,
                DisplayText = $"{d.Length} x {d.Width} x {d.Height}"
            });
            ViewData["Dimensions"] = new SelectList(dimensionSelectList, "Id", "DisplayText");

            return await base.Create();
        }

        public override Task<IActionResult> CreateSubmit(BookBase model)
        {
            return base.CreateSubmit(model);
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

        public override async Task<IActionResult> Edit(int id)
        {
            var subcategories = await _subcategoryService.FilterAsync(new FilterOptions());
            ViewData["Subcategories"] = new SelectList(subcategories.Data?.Paged.Items, "Id", "Name");

            var authors = await _authorService.FilterAsync(new FilterOptions());
            ViewData["Authors"] = new SelectList(authors.Data?.Paged.Items, "Id", "Name");

            var coverTypes = await _coverTypeService.FilterAsync(new FilterOptions());
            ViewData["CoverTypes"] = new SelectList(coverTypes.Data?.Paged.Items, "Id", "TypeName");

            var dimensions = await _dimensionService.FilterAsync(new FilterOptions());
            var dimensionSelectList = dimensions.Data?.Paged.Items.Select(d => new
            {
                Id = d.Id,
                DisplayText = $"{d.Length} x {d.Width} x {d.Height}"
            });
            ViewData["Dimensions"] = new SelectList(dimensionSelectList, "Id", "DisplayText");
            return await base.Edit(id);
        }

        public override Task<IActionResult> Edit(int id, BookBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override async Task<IActionResult> Index(FilterOptions filterOptions)
        {
            var subcategories = await _subcategoryService.FilterAsync(new FilterOptions());
            ViewData["Subcategories"] = new SelectList(subcategories.Data?.Paged.Items, "Name", "Name");

            var authors = await _authorService.FilterAsync(new FilterOptions());
            ViewData["Authors"] = new SelectList(authors.Data?.Paged.Items, "Name", "Name");

            var coverTypes = await _coverTypeService.FilterAsync(new FilterOptions());
            ViewData["CoverTypes"] = new SelectList(coverTypes.Data?.Paged.Items, "TypeName", "TypeName");

            var dimensions = await _dimensionService.FilterAsync(new FilterOptions());
            var dimensionSelectList = dimensions.Data?.Paged.Items.Select(d => new
            {
                Id = d.Id,
                DisplayText = $"{d.Length} x {d.Width} x {d.Height}"
            });
            ViewData["Dimensions"] = new SelectList(dimensionSelectList, "DisplayText", "DisplayText");

            return await base.Index(filterOptions);
        }
    }
    #endregion

    #region BookPartner 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminBookPartnersController : BaseController<AdminBookPartners, BookPartnerDetail, BookPartnerExtend, BookPartnerBase>
    {
        private readonly IAdminBookPartnerService _service;

        public AdminBookPartnersController(IAdminBookPartnerService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(BookPartnerBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, BookPartnerBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region Cart Ignore
    //[Authorize(Policy = AppRole.Admin)]
    //[Area("Admin")]
    //public class AdminCartsController : BaseController<AdminCarts, CartDetail, CartExtend, CartBase>
    //{
    //    private readonly IAdminCartService _service;

    //    public AdminCartsController(IAdminCartService service) : base(service)
    //    {
    //        _service = service;
    //    }

    //    public override Task<IActionResult> Create()
    //    {
    //        return base.Create();
    //    }

    //    public override Task<IActionResult> CreateSubmit(CartBase model)
    //    {
    //        return base.CreateSubmit(model);
    //    }

    //    public override Task<IActionResult> Delete(int id)
    //    {
    //        return base.Delete(id);
    //    }

    //    public override Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        return base.DeleteConfirmed(id);
    //    }

    //    public override Task<IActionResult> Details(int id)
    //    {
    //        return base.Details(id);
    //    }

    //    public override Task<IActionResult> Edit(int id)
    //    {
    //        return base.Edit(id);
    //    }

    //    public override Task<IActionResult> Edit(int id, CartBase model)
    //    {
    //        return base.Edit(id, model);
    //    }

    //    public override Task<IActionResult> Filter(FilterOptions filterOptions)
    //    {
    //        return base.Filter(filterOptions);
    //    }

    //    public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
    //    {
    //        return base.FilterSubmit(filterOptions);
    //    }

    //    public override Task<IActionResult> Index(FilterOptions filterOptions)
    //    {
    //        return base.Index(filterOptions);
    //    }
    //}
    #endregion

    #region CartItem Ignore
    //[Authorize(Policy = AppRole.Admin)]
    //[Area("Admin")]
    //public class AdminCartItemsController : BaseController<AdminCartItems, CartItemDetail, CartItemExtend, CartItemBase>
    //{
    //    private readonly IAdminCartItemService _service;

    //    public AdminCartItemsController(IAdminCartItemService service) : base(service)
    //    {
    //        _service = service;
    //    }

    //    public override Task<IActionResult> Create()
    //    {
    //        return base.Create();
    //    }

    //    public override Task<IActionResult> CreateSubmit(CartItemBase model)
    //    {
    //        return base.CreateSubmit(model);
    //    }

    //    public override Task<IActionResult> Delete(int id)
    //    {
    //        return base.Delete(id);
    //    }

    //    public override Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        return base.DeleteConfirmed(id);
    //    }

    //    public override Task<IActionResult> Details(int id)
    //    {
    //        return base.Details(id);
    //    }

    //    public override Task<IActionResult> Edit(int id)
    //    {
    //        return base.Edit(id);
    //    }

    //    public override Task<IActionResult> Edit(int id, CartItemBase model)
    //    {
    //        return base.Edit(id, model);
    //    }

    //    public override Task<IActionResult> Filter(FilterOptions filterOptions)
    //    {
    //        return base.Filter(filterOptions);
    //    }

    //    public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
    //    {
    //        return base.FilterSubmit(filterOptions);
    //    }

    //    public override Task<IActionResult> Index(FilterOptions filterOptions)
    //    {
    //        return base.Index(filterOptions);
    //    }
    //}
    #endregion

    #region Category 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminCategoriesController : BaseController<AdminCategories, CategoryDetail, CategoryExtend, CategoryBase>
    {
        private readonly IAdminCategoryService _service;

        public AdminCategoriesController(IAdminCategoryService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(CategoryBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, CategoryBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region CoverType 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminCoverTypesController : BaseController<AdminCoverTypes, CoverTypeDetail, CoverTypeExtend, CoverTypeBase>
    {
        private readonly IAdminCoverTypeService _service;

        public AdminCoverTypesController(IAdminCoverTypeService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(CoverTypeBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, CoverTypeBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region Dimension 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminDimensionsController : BaseController<AdminDimensions, DimensionDetail, DimensionExtend, DimensionBase>
    {
        private readonly IAdminDimensionService _service;

        public AdminDimensionsController(IAdminDimensionService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(DimensionBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, DimensionBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region Favourite Ignore
    //[Authorize(Policy = AppRole.Admin)]
    //[Area("Admin")]
    //public class AdminFavouritesController : BaseController<AdminFavourites, FavouriteDetail, FavouriteExtend, FavouriteBase>
    //{
    //    private readonly IAdminFavouriteService _service;

    //    public AdminFavouritesController(IAdminFavouriteService service) : base(service)
    //    {
    //        _service = service;
    //    }

    //    public override Task<IActionResult> Create()
    //    {
    //        return base.Create();
    //    }

    //    public override Task<IActionResult> CreateSubmit(FavouriteBase model)
    //    {
    //        return base.CreateSubmit(model);
    //    }

    //    public override Task<IActionResult> Delete(int id)
    //    {
    //        return base.Delete(id);
    //    }

    //    public override Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        return base.DeleteConfirmed(id);
    //    }

    //    public override Task<IActionResult> Details(int id)
    //    {
    //        return base.Details(id);
    //    }

    //    public override Task<IActionResult> Edit(int id)
    //    {
    //        return base.Edit(id);
    //    }

    //    public override Task<IActionResult> Edit(int id, FavouriteBase model)
    //    {
    //        return base.Edit(id, model);
    //    }

    //    public override Task<IActionResult> Filter(FilterOptions filterOptions)
    //    {
    //        return base.Filter(filterOptions);
    //    }

    //    public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
    //    {
    //        return base.FilterSubmit(filterOptions);
    //    }

    //    public override Task<IActionResult> Index(FilterOptions filterOptions)
    //    {
    //        return base.Index(filterOptions);
    //    }
    //}
    #endregion

    #region FlashSale 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminFlashSalesController : BaseController<AdminFlashSales, FlashSaleDetail, FlashSaleExtend, FlashSaleBase>
    {
        private readonly IAdminFlashSaleService _service;

        public AdminFlashSalesController(IAdminFlashSaleService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(FlashSaleBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, FlashSaleBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region FlashSaleBook 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminFlashSaleBooksController : BaseController<AdminFlashSaleBooks, FlashSaleBookDetail, FlashSaleBookExtend, FlashSaleBookBase>
    {
        private readonly IAdminFlashSaleBookService _service;
        private readonly IAdminFlashSaleService _flashSaleService;

        public AdminFlashSaleBooksController(IAdminFlashSaleBookService service, IAdminFlashSaleService flashSaleService) : base(service)
        {
            _service = service;
            _flashSaleService = flashSaleService;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(FlashSaleBookBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, FlashSaleBookBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override async Task<IActionResult> Index(FilterOptions filterOptions)
        {
            var flashSales = await _flashSaleService.FilterAsync(new FilterOptions());
            var flashSaleSelectList = flashSales.Data?.Paged.Items.Select(d => new
            {
                Id = d.Id,
                DisplayText = $"{d.Id}: {d.StartDate}"
            });
            ViewData["FlashSales"] = new SelectList(flashSaleSelectList, "Id", "DisplayText");
            return await base.Index(filterOptions);
        }
    }
    #endregion

    #region Menu 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminMenusController : BaseController<AdminMenus, MenuDetail, MenuExtend, MenuBase>
    {
        private readonly IAdminMenuService _service;

        public AdminMenusController(IAdminMenuService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(MenuBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, MenuBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region Notification 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminNotificationsController : BaseController<AdminNotifications, NotificationDetail, NotificationExtend, NotificationBase>
    {
        private readonly IAdminNotificationService _service;
        private readonly IAdminNotificationTypeService _notificationTypeService;

        public AdminNotificationsController(IAdminNotificationService service, IAdminNotificationTypeService notificationTypeService) : base(service)
        {
            _service = service;
            _notificationTypeService = notificationTypeService;
        }

        public override async Task<IActionResult> Create()
        {
            var notificationTypes = await _notificationTypeService.FilterAsync(new FilterOptions());
            ViewData["NotificationTypes"] = new SelectList(notificationTypes.Data?.Paged.Items, "Id", "Name");
            return await base.Create();
        }

        public override Task<IActionResult> CreateSubmit(NotificationBase model)
        {
            return base.CreateSubmit(model);
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

        public override async Task<IActionResult> Edit(int id)
        {
            var notificationTypes = await _notificationTypeService.FilterAsync(new FilterOptions());
            ViewData["NotificationTypes"] = new SelectList(notificationTypes.Data?.Paged.Items, "Id", "Name");
            return await base.Edit(id);
        }

        public override Task<IActionResult> Edit(int id, NotificationBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override async Task<IActionResult> Index(FilterOptions filterOptions)
        {
            var notificationTypes = await _notificationTypeService.FilterAsync(new FilterOptions());
            ViewData["NotificationTypes"] = new SelectList(notificationTypes.Data?.Paged.Items, "Id", "Name");
            return await base.Index(filterOptions);
        }
    }
    #endregion

    #region NotificationType 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminNotificationTypesController : BaseController<AdminNotificationTypes, NotificationTypeDetail, NotificationTypeExtend, NotificationTypeBase>
    {
        private readonly IAdminNotificationTypeService _service;

        public AdminNotificationTypesController(IAdminNotificationTypeService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(NotificationTypeBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, NotificationTypeBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region Order 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminOrdersController : BaseController<AdminOrders, OrderDetail, OrderExtend, OrderBase>
    {
        private readonly IAdminOrderService _service;
        private readonly IAdminStatusService _statusService;
        private readonly IAdminOrderStatusService _orderStatusService;

        public AdminOrdersController(IAdminOrderService service, IAdminStatusService statusService, IAdminOrderStatusService orderStatusService) : base(service)
        {
            _service = service;
            _statusService = statusService;
            _orderStatusService = orderStatusService;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public async Task<IActionResult> UpdateOrderStatus(int id)
        {
            var statuses = await _statusService.FilterAsync(new FilterOptions());
            ViewData["Statuses"] = new SelectList(statuses.Data?.Paged.Items, "Id", "Name");
            ViewData["OrderId"] = id;
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrderStatus(int id, OrderStatusBase model)
        {
            model.Id = 0;
            model.OrderId = id;
            if (!ModelState.IsValid)
            {
                await UpdateOrderStatus(id);
                return PartialView(model);
            }
            var repository = await _orderStatusService.AddAsync(model);
            if (repository != null && !repository.Error)
            {
                return RedirectToAction("Filter");
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
        }

        public override Task<IActionResult> CreateSubmit(OrderBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, OrderBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override async Task<IActionResult> Index(FilterOptions filterOptions)
        {
            var statuses = await _statusService.FilterAsync(new FilterOptions());
            ViewData["Statuses"] = new SelectList(statuses.Data?.Paged.Items, "Name", "Name");
            return await base.Index(filterOptions);
        }
    }
    #endregion

    #region OrderItem Ignore
    //[Authorize(Policy = AppRole.Admin)]
    //[Area("Admin")]
    //public class AdminOrderItemsController : BaseController<AdminOrderItems, OrderItemDetail, OrderItemExtend, OrderItemBase>
    //{
    //    private readonly IAdminOrderItemService _service;

    //    public AdminOrderItemsController(IAdminOrderItemService service) : base(service)
    //    {
    //        _service = service;
    //    }

    //    public override Task<IActionResult> Create()
    //    {
    //        return base.Create();
    //    }

    //    public override Task<IActionResult> CreateSubmit(OrderItemBase model)
    //    {
    //        return base.CreateSubmit(model);
    //    }

    //    public override Task<IActionResult> Delete(int id)
    //    {
    //        return base.Delete(id);
    //    }

    //    public override Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        return base.DeleteConfirmed(id);
    //    }

    //    public override Task<IActionResult> Details(int id)
    //    {
    //        return base.Details(id);
    //    }

    //    public override Task<IActionResult> Edit(int id)
    //    {
    //        return base.Edit(id);
    //    }

    //    public override Task<IActionResult> Edit(int id, OrderItemBase model)
    //    {
    //        return base.Edit(id, model);
    //    }

    //    public override Task<IActionResult> Filter(FilterOptions filterOptions)
    //    {
    //        return base.Filter(filterOptions);
    //    }

    //    public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
    //    {
    //        return base.FilterSubmit(filterOptions);
    //    }

    //    public override Task<IActionResult> Index(FilterOptions filterOptions)
    //    {
    //        return base.Index(filterOptions);
    //    }
    //}
    #endregion

    #region OrderStatus 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminOrderStatusesController : BaseController<AdminOrderStatuses, OrderStatusDetail, OrderStatusExtend, OrderStatusBase>
    {
        private readonly IAdminOrderStatusService _service;

        public AdminOrderStatusesController(IAdminOrderStatusService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(OrderStatusBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, OrderStatusBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region Partner 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminPartnersController : BaseController<AdminPartners, PartnerDetail, PartnerExtend, PartnerBase>
    {
        private readonly IAdminPartnerService _service;
        private readonly IAdminPartnerTypeService _partnerTypeService;

        public AdminPartnersController(IAdminPartnerService service, IAdminPartnerTypeService partnerTypeService) : base(service)
        {
            _service = service;
            _partnerTypeService = partnerTypeService;
        }

        public override async Task<IActionResult> Create()
        {
            var partnerTypes = await _partnerTypeService.FilterAsync(new FilterOptions());
            ViewData["PartnerTypes"] = new SelectList(partnerTypes.Data?.Paged.Items, "Id", "Name");
            return await base.Create();
        }

        public override Task<IActionResult> CreateSubmit(PartnerBase model)
        {
            return base.CreateSubmit(model);
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

        public override async Task<IActionResult> Edit(int id)
        {
            var partnerTypes = await _partnerTypeService.FilterAsync(new FilterOptions());
            ViewData["PartnerTypes"] = new SelectList(partnerTypes.Data?.Paged.Items, "Id", "Name");
            return await base.Edit(id);
        }

        public override Task<IActionResult> Edit(int id, PartnerBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override async Task<IActionResult> Index(FilterOptions filterOptions)
        {
            var partnerTypes = await _partnerTypeService.FilterAsync(new FilterOptions());
            ViewData["PartnerTypes"] = new SelectList(partnerTypes.Data?.Paged.Items, "Name", "Name");
            return await base.Index(filterOptions);
        }
    }
    #endregion

    #region PartnerType 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminPartnerTypesController : BaseController<AdminPartnerTypes, PartnerTypeDetail, PartnerTypeExtend, PartnerTypeBase>
    {
        private readonly IAdminPartnerTypeService _service;

        public AdminPartnerTypesController(IAdminPartnerTypeService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(PartnerTypeBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, PartnerTypeBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region PaymentMethod 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminPaymentMethodsController : BaseController<AdminPaymentMethods, PaymentMethodDetail, PaymentMethodExtend, PaymentMethodBase>
    {
        private readonly IAdminPaymentMethodService _service;

        public AdminPaymentMethodsController(IAdminPaymentMethodService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(PaymentMethodBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, PaymentMethodBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region Platform 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminPlatformsController : BaseController<AdminPlatforms, PlatformDetail, PlatformExtend, PlatformBase>
    {
        private readonly IAdminPlatformService _service;

        public AdminPlatformsController(IAdminPlatformService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(PlatformBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, PlatformBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region PosterImage 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminPosterImagesController : BaseController<AdminPosterImages, PosterImageDetail, PosterImageExtend, PosterImageBase>
    {
        private readonly IAdminPosterImageService _service;

        public AdminPosterImagesController(IAdminPosterImageService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(PosterImageBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, PosterImageBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region Review Ignore
    //[Authorize(Policy = AppRole.Admin)]
    //[Area("Admin")]
    //public class AdminReviewsController : BaseController<AdminReviews, ReviewDetail, ReviewExtend, ReviewBase>
    //{
    //    private readonly IAdminReviewService _service;

    //    public AdminReviewsController(IAdminReviewService service) : base(service)
    //    {
    //        _service = service;
    //    }

    //    public override Task<IActionResult> Create()
    //    {
    //        return base.Create();
    //    }

    //    public override Task<IActionResult> CreateSubmit(ReviewBase model)
    //    {
    //        return base.CreateSubmit(model);
    //    }

    //    public override Task<IActionResult> Delete(int id)
    //    {
    //        return base.Delete(id);
    //    }

    //    public override Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        return base.DeleteConfirmed(id);
    //    }

    //    public override Task<IActionResult> Details(int id)
    //    {
    //        return base.Details(id);
    //    }

    //    public override Task<IActionResult> Edit(int id)
    //    {
    //        return base.Edit(id);
    //    }

    //    public override Task<IActionResult> Edit(int id, ReviewBase model)
    //    {
    //        return base.Edit(id, model);
    //    }

    //    public override Task<IActionResult> Filter(FilterOptions filterOptions)
    //    {
    //        return base.Filter(filterOptions);
    //    }

    //    public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
    //    {
    //        return base.FilterSubmit(filterOptions);
    //    }

    //    public override Task<IActionResult> Index(FilterOptions filterOptions)
    //    {
    //        return base.Index(filterOptions);
    //    }
    //}
    #endregion

    #region Status 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminStatusesController : BaseController<AdminStatuses, StatusDetail, StatusExtend, StatusBase>
    {
        private readonly IAdminStatusService _service;

        public AdminStatusesController(IAdminStatusService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(StatusBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, StatusBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region Subcategory 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminSubcategoriesController : BaseController<AdminSubcategories, SubcategoryDetail, SubcategoryExtend, SubcategoryBase>
    {
        private readonly IAdminSubcategoryService _service;
        private readonly IAdminCategoryService _categoryService;

        public AdminSubcategoriesController(IAdminSubcategoryService service, IAdminCategoryService categoryService) : base(service)
        {
            _service = service;
            _categoryService = categoryService;
        }

        public override async Task<IActionResult> Create()
        {
            var categories = await _categoryService.FilterAsync(new FilterOptions());
            ViewData["Categories"] = new SelectList(categories.Data?.Paged.Items, "Id", "Name");
            return await base.Create();
        }

        public override Task<IActionResult> CreateSubmit(SubcategoryBase model)
        {
            return base.CreateSubmit(model);
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

        public override async Task<IActionResult> Edit(int id)
        {
            var categories = await _categoryService.FilterAsync(new FilterOptions());
            ViewData["Categories"] = new SelectList(categories.Data?.Paged.Items, "Id", "Name");
            return await base.Edit(id);
        }

        public override Task<IActionResult> Edit(int id, SubcategoryBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override async Task<IActionResult> Index(FilterOptions filterOptions)
        {
            var categories = await _categoryService.FilterAsync(new FilterOptions());
            ViewData["Categories"] = new SelectList(categories.Data?.Paged.Items, "Name", "Name");
            return await base.Index(filterOptions);
        }
    }
    #endregion

    #region Topic 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminTopicsController : BaseController<AdminTopics, TopicDetail, TopicExtend, TopicBase>
    {
        private readonly IAdminTopicService _service;

        public AdminTopicsController(IAdminTopicService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(TopicBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, TopicBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region TopicContent 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminTopicContentsController : BaseController<AdminTopicContents, TopicContentDetail, TopicContentExtend, TopicContentBase>
    {
        private readonly IAdminTopicContentService _service;

        public AdminTopicContentsController(IAdminTopicContentService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(TopicContentBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, TopicContentBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region Voucher 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminVouchersController : BaseController<AdminVouchers, VoucherDetail, VoucherExtend, VoucherBase>
    {
        private readonly IAdminVoucherService _service;

        public AdminVouchersController(IAdminVoucherService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(VoucherBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, VoucherBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #region Website 
    [Authorize(Policy = AppRole.Admin)]
    [Area("Admin")]
    public class AdminWebsitesController : BaseController<AdminWebsites, WebsiteDetail, WebsiteExtend, WebsiteBase>
    {
        private readonly IAdminWebsiteService _service;

        public AdminWebsitesController(IAdminWebsiteService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Create()
        {
            return base.Create();
        }

        public override Task<IActionResult> CreateSubmit(WebsiteBase model)
        {
            return base.CreateSubmit(model);
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

        public override Task<IActionResult> Edit(int id, WebsiteBase model)
        {
            return base.Edit(id, model);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }
    }
    #endregion

    #endregion
}
