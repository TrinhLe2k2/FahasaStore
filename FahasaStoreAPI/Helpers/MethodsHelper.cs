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
                PagedNavigation =
                {
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
                }
            };
        }
    }
}
