using AutoMapper;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Helpers;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Models.ViewModels.Entities;
using FahasaStoreAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                .Select(flashSale => new FlashSaleVM
                {
                    Id = flashSale.Id,
                    StartDate = flashSale.StartDate,
                    EndDate = flashSale.EndDate,
                    FlashSaleBooks = flashSale.FlashSaleBooks
                        .Select(fsb => new FlashSaleBookVM
                        {
                            DiscountPercentage = fsb.DiscountPercentage,
                            Quantity = fsb.Quantity,

                            PriceFS = (fsb.Book.Price * 100 - fsb.Book.Price * fsb.DiscountPercentage) / 100,
                            Solded = fsb.Book.OrderItems.Count,
                            Book = new BookVM
                            {
                                Id = fsb.Book.Id,
                                SubcategoryId = fsb.Book.SubcategoryId,
                                AuthorId = fsb.Book.AuthorId,
                                CoverTypeId = fsb.Book.CoverTypeId,
                                DimensionId = fsb.Book.DimensionId,

                                Name = fsb.Book.Name,
                                Description = fsb.Book.Description,
                                Price = fsb.Book.Price,
                                DiscountPercentage = fsb.Book.DiscountPercentage,
                                Quantity = fsb.Book.Quantity,
                                Weight = fsb.Book.Weight,
                                PageCount = fsb.Book.PageCount,
                                CreatedAt = fsb.Book.CreatedAt,

                                RateAverage = fsb.Book.Reviews.Any() ? fsb.Book.Reviews.Average(r => r.Rating) : 0,
                                RateCount = fsb.Book.Reviews.Count(),
                                Solded = fsb.Book.OrderItems.Sum(o => o.Quantity),
                                CurrentPrice = (fsb.Book.Price * 100 - fsb.Book.Price * fsb.Book.DiscountPercentage) / 100,
                                FavouritesCount = fsb.Book.Favourites.Count,

                                Author = fsb.Book.Author,
                                CoverType = fsb.Book.CoverType,
                                Dimension = fsb.Book.Dimension,
                                Subcategory = fsb.Book.Subcategory,

                                BookPartners = fsb.Book.BookPartners.Select(bp => new BookPartnerVM
                                {
                                    PartnerId = bp.PartnerId,
                                    PartnerName = bp.Partner.Name,
                                    PartnerTypeId = bp.Partner.PartnerTypeId,
                                    PartnerType = bp.Partner.PartnerType.Name
                                }).ToList(),
                                PosterImages = fsb.Book.PosterImages
                            }
                        })
                        .ToPagedList(pageNumber, pageSize)
                })
                .FirstOrDefaultAsync(e => e.StartDate <= today && e.EndDate >= today);

            return flashSaleToday;
        }

        public async Task<IPagedList<BookVM>> TrendingBooks(string trendingBy, int pageNumber, int pageSize)
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
                .Where(b => b.OrderItems.Any(oi => oi.Order.CreatedAt >= startDate && oi.Order.CreatedAt <= endDate))
                .Select(MethodsHelper.BookToBookVM())
                .OrderByDescending(b => b.Solded)
                .ToPagedListAsync(pageNumber, pageSize);
                                      
            return trendingBooks;
        }

        public async Task<IPagedList<BookVM>> TopSellingBooksByCategory(int categoryId, int pageNumber, int pageSize)
        {
            var topSellingBooks = await _context.Books.AsNoTracking()
                .Where(b => b.Subcategory.CategoryId == categoryId)
                .Select(MethodsHelper.BookToBookVM())
                .OrderByDescending(b => b.Solded)
                .ToPagedListAsync(pageNumber, pageSize);

            return topSellingBooks;
        }
    }
}
