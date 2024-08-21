using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Models.ViewModels.Entities;
using System.Linq.Expressions;
using X.PagedList;

namespace FahasaStoreAPI.Helpers
{
    public static class MethodsHelper
    {
        public static PagedVM<T> GetPagedAsync<T>(IPagedList<T> pagedList)
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

            return new PagedVM<T>
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

        public static Expression<Func<Book, BookVM>> BookToBookVM()
        {
            return book => new BookVM
            {
                Id = book.Id,
                SubcategoryId = book.SubcategoryId,
                AuthorId = book.AuthorId,
                CoverTypeId = book.CoverTypeId,
                DimensionId = book.DimensionId,

                Name = book.Name,
                Description = book.Description,
                Price = book.Price,
                DiscountPercentage = book.DiscountPercentage,
                Quantity = book.Quantity,
                Weight = book.Weight,
                PageCount = book.PageCount,
                CreatedAt = book.CreatedAt,

                RateAverage = book.Reviews.Any() ? book.Reviews.Average(r => r.Rating) : 0,
                RateCount = book.Reviews.Count(),
                Solded = book.OrderItems.Sum(o => o.Quantity),
                CurrentPrice = (book.Price * 100 - book.Price * book.DiscountPercentage) / 100,
                FavouritesCount = book.Favourites.Count,

                Author = book.Author,
                CoverType = book.CoverType,
                Dimension = book.Dimension,
                Subcategory = book.Subcategory,

                //BookPartners = book.BookPartners,
                BookPartners = book.BookPartners.Select(bp => new BookPartnerVM
                {
                    PartnerId = bp.PartnerId,
                    PartnerName = bp.Partner.Name,
                    PartnerTypeId = bp.Partner.PartnerTypeId,
                    PartnerType = bp.Partner.PartnerType.Name
                }).ToList(),
                PosterImages = book.PosterImages
            };
        }
    }
}
