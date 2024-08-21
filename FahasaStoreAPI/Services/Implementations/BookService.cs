using AutoMapper;
using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Models.ViewModels.Entities;
using FahasaStoreAPI.Repositories.Interfaces;
using FahasaStoreAPI.Services.Extensions;
using FahasaStoreAPI.Services.Interfaces;
using X.PagedList;

namespace FahasaStoreAPI.Services.Implementations
{
    public class BookService : BaseService<Book, BookCreateDto, BookEditDto, int>, IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBaseRepository<Book, int> repository, IMapper mapper, ICloudinaryService cloudinaryService, IBookRepository bookRepository) : base(repository, mapper, cloudinaryService)
        {
            _bookRepository = bookRepository;
        }

        async Task<BookVM?> IBookService.FindByIdAsync(int id)
        {
            var result = await _bookRepository.FindByIdAsync(id);
            return result;
        }

        async Task<FilterVM<BookVM>> IBookService.FilterAsync(FilterOptions filterOptions)
        {
            IPagedList<BookVM> pagedList = await _bookRepository.FilterAsync(filterOptions);
            var paged = GetPagedAsync(pagedList);
            var result = new FilterVM<BookVM>(filterOptions, paged);
            return result;
        }

        private PagedVM<BookVM> GetPagedAsync(IPagedList<BookVM> pagedList)
        {
            int maxPages = 5;
            int totalPages = pagedList.PageCount;
            int pageNumber = pagedList.PageNumber;

            int startPage = Math.Max(1, pageNumber - maxPages / 2);
            if (startPage + maxPages - 1 > totalPages)
            {
                startPage = Math.Max(1, totalPages - maxPages + 1);
            }

            int endPage = Math.Min(totalPages, pageNumber + maxPages / 2);
            if (endPage < maxPages)
            {
                endPage = Math.Min(totalPages, maxPages);
            }

            return new PagedVM<BookVM>
            {
                Items = pagedList.ToList(),
                PageNumber = pagedList.PageNumber,
                PageSize = pagedList.PageSize,
                TotalItemCount = pagedList.TotalItemCount,
                PageCount = pagedList.PageCount,
                HasNextPage = pagedList.HasNextPage,
                HasPreviousPage = pagedList.HasPreviousPage,
                IsFirstPage = pagedList.IsFirstPage,
                IsLastPage = pagedList.IsLastPage,
                StartPage = startPage,
                EndPage = endPage
            };
        }
    }
}
