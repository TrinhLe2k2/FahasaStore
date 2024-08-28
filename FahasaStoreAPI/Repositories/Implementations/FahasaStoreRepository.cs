using AutoMapper;
using AutoMapper.QueryableExtensions;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Helpers;
using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Models.ViewModels.Entities;
using FahasaStoreAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using X.PagedList;

namespace FahasaStoreAPI.Repositories.Implementations
{
    public class FahasaStoreRepository : IFahasaStoreRepository
    {
        protected readonly FahasaStoreDBContext _context;
        protected readonly IMapper _mapper;

        public FahasaStoreRepository(FahasaStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FlashSaleVM?> FlashSaleTodayAsync(int pageNumber, int pageSize)
        {
            var today = DateTime.Today;

            var flashSaleToday = await _context.FlashSales.AsNoTracking()
                .ProjectTo<FlashSaleVM>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => e.StartDate <= today && e.EndDate >= today);
            return flashSaleToday;
        }

        public async Task<IPagedList<BookDto>> TrendingBooks(string trendingBy, int pageNumber, int pageSize)
        {
            var startDate = DateTime.Today;
            var endDate = DateTime.Today;
            switch (trendingBy)
            {
                case TrendingBy.Monthly:
                    endDate = startDate.AddMonths(1);
                    break;
                case TrendingBy.Yearly:
                    endDate = startDate.AddYears(1);
                    break;
                default:
                    endDate = startDate.AddDays(1);
                    break;
            }

            var trendingBooks = await _context.Books.AsNoTracking()
                .Where(b => b.OrderItems.Any(oi => oi.Order != null && oi.Order.CreatedAt >= startDate && oi.Order.CreatedAt <= endDate))
                .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                .OrderByDescending(b => b.Solded)
                .ToPagedListAsync(pageNumber, pageSize);
                                      
            return trendingBooks;
        }

        public async Task<IPagedList<BookVM>> TopSellingBooksByCategory(int categoryId, int pageNumber, int pageSize)
        {
            var topSellingBooks = await _context.Books.AsNoTracking()
                .Where(b => b.Subcategory != null && b.Subcategory.CategoryId == categoryId)
                .ProjectTo<BookVM>(_mapper.ConfigurationProvider)
                .OrderByDescending(b => b.Solded)
                .ToPagedListAsync(pageNumber, pageSize);

            return topSellingBooks;
        }

        public async Task<DataOptionsFilterBook> DataOptionsFilterBook()
        {
            var categories = await _context.Categories.AsNoTracking()
                .ProjectTo<CategoryVM>(_mapper.ConfigurationProvider)
                .OrderBy(c => c.Name)
                .ToListAsync();

            var partnerTypes = await _context.PartnerTypes.AsNoTracking()
                .ProjectTo<PartnerTypeVM>(_mapper.ConfigurationProvider)
                .OrderBy(c => c.Name)
                .ToListAsync();
            var authors = await _context.Authors.AsNoTracking()
                .ProjectTo<AuthorDto>(_mapper.ConfigurationProvider).OrderBy(c => c.Name)
                .ToListAsync();
            var coverTypes = await _context.CoverTypes.AsNoTracking()
                .ProjectTo<CoverTypeDto>(_mapper.ConfigurationProvider).OrderBy(c => c.TypeName)
                .ToListAsync();
            var dimensions = await _context.Dimensions.AsNoTracking()
                .ProjectTo<DimensionDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var dataOptionsFilterBook = new DataOptionsFilterBook
            {
                Categories = categories,
                PartnerTypes = partnerTypes,
                Authors = authors,
                CoverTypes = coverTypes,
                Dimensions = dimensions
            };
            return dataOptionsFilterBook;
        }

        public async Task<ResultFilterBook> FilterBook(OptionsFilterBook optionsFilterBook)
        {
            var query = _context.Books.AsNoTracking().AsQueryable();
            #region step 1: Filter Book
            if (optionsFilterBook.CategoryId.HasValue)
            {
                query = query.Where(b => b.Subcategory != null && b.Subcategory.CategoryId == optionsFilterBook.CategoryId.Value);
            }

            if (optionsFilterBook.SubcategoryId.HasValue)
            {
                query = query.Where(b => b.SubcategoryId == optionsFilterBook.SubcategoryId.Value);
            }

            if (optionsFilterBook.AuthorId.HasValue)
            {
                query = query.Where(b => b.AuthorId == optionsFilterBook.AuthorId.Value);
            }

            if (optionsFilterBook.PartnerTypeId.HasValue)
            {
                query = query.Where(b => b.BookPartners.Any(bp => bp.Partner != null && bp.Partner.PartnerTypeId == optionsFilterBook.PartnerTypeId.Value));
            }

            if (optionsFilterBook.PartnerId.HasValue)
            {
                query = query.Where(b => b.BookPartners.Any(bp => bp.PartnerId == optionsFilterBook.PartnerId.Value));
            }

            if (optionsFilterBook.CoverTypeId.HasValue)
            {
                query = query.Where(b => b.CoverTypeId == optionsFilterBook.CoverTypeId.Value);
            }

            if (optionsFilterBook.DimensionId.HasValue)
            {
                query = query.Where(b => b.DimensionId == optionsFilterBook.DimensionId.Value);
            }

            #endregion

            #region step 2: Filter BookDto
            var queryForBookDto = query.ProjectTo<BookDto>(_mapper.ConfigurationProvider);

            if (optionsFilterBook.MinPrice.HasValue)
            {
                queryForBookDto = queryForBookDto.Where(b => b.CurrentPrice >= optionsFilterBook.MinPrice.Value);
            }

            if (optionsFilterBook.MaxPrice.HasValue)
            {
                queryForBookDto = queryForBookDto.Where(b => b.CurrentPrice <= optionsFilterBook.MaxPrice.Value);
            }

            if (!string.IsNullOrEmpty(optionsFilterBook.SearchName))
            {
                queryForBookDto = queryForBookDto.Where(b => b.Name.Contains(optionsFilterBook.SearchName));
            }

            #endregion

            #region step 3: OrderBy
            if (!string.IsNullOrEmpty(optionsFilterBook.SortBy) && typeof(BookDto).GetProperty(optionsFilterBook.SortBy) != null)
            {
                if (optionsFilterBook.SortDescending)
                {
                    queryForBookDto = queryForBookDto.OrderByDescending(e => EF.Property<object>(e, optionsFilterBook.SortBy));
                }
                else
                {
                    queryForBookDto = queryForBookDto.OrderBy(e => EF.Property<object>(e, optionsFilterBook.SortBy));
                }
            }
            #endregion
            var pageListBook = await queryForBookDto.ToPagedListAsync(optionsFilterBook.PageNumber, optionsFilterBook.PageSize);
            var result = new ResultFilterBook
            {
                optionsFilterBook = optionsFilterBook,
                books = MethodsHelper.GetPagedAsync(pageListBook)
            };
            return result;
        }
    }
}
