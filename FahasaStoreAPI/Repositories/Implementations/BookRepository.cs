using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Helpers;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Models.ViewModels.Entities;
using FahasaStoreAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Dynamic.Core;
using X.PagedList;

namespace FahasaStoreAPI.Repositories.Implementations
{
    public class BookRepository : BaseRepository<Book, int>, IBookRepository
    {
        public BookRepository(FahasaStoreDBContext context) : base(context)
        {
        }

        async Task<IPagedList<BookVM>> IBookRepository.FilterAsync(FilterOptions filterOptions)
        {
            IQueryable<Book> query = _context.Books.AsNoTracking();

            if (filterOptions.Filters != null && filterOptions.Filters.Count > 0)
            {
                foreach (var filter in filterOptions.Filters)
                {
                    string key = filter.Key;
                    string? value = filter.Value;
                    string typeOfKey = filter.TypeOfKey;
                    string comparisonOperator = filter.ComparisonOperator;

                    if (!string.IsNullOrEmpty(key) && typeof(Book).GetProperty(key) != null && !string.IsNullOrEmpty(value))
                    {
                        switch (typeOfKey.ToLower())
                        {
                            case "string":
                                if (comparisonOperator == "=")
                                {
                                    query = query.Where($"{key}.Contains(@0)", value);
                                }
                                break;
                            case "int":
                                if (int.TryParse(value, out int intValue))
                                {
                                    switch (comparisonOperator)
                                    {
                                        case "=":
                                            query = query.Where($"{key} == @0", intValue);
                                            break;
                                        case "<=":
                                            query = query.Where($"{key} <= @0", intValue);
                                            break;
                                        case ">=":
                                            query = query.Where($"{key} >= @0", intValue);
                                            break;
                                    }
                                }
                                break;
                            case "datetime":
                                if (DateTime.TryParse(value, out DateTime dateValue))
                                {
                                    switch (comparisonOperator)
                                    {
                                        case "=":
                                            query = query.Where($"{key} == @0", dateValue);
                                            break;
                                        case "<=":
                                            query = query.Where($"{key} <= @0", dateValue);
                                            break;
                                        case ">=":
                                            query = query.Where($"{key} >= @0", dateValue);
                                            break;
                                        case "<":
                                            query = query.Where($"{key} < @0", dateValue);
                                            break;
                                        case ">":
                                            query = query.Where($"{key} > @0", dateValue);
                                            break;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(filterOptions.SortField) && typeof(Book).GetProperty(filterOptions.SortField) != null)
            {
                query = query.OrderBy($"{filterOptions.SortField} {(filterOptions.OrderByDescending ? "desc" : "asc")}");
            }
            else
            {
                query = query.OrderBy(e => e.Id);
            }

            var result = await query.Select(MethodsHelper.BookToBookVM()).ToPagedListAsync(filterOptions.PageNumber, filterOptions.PageSize);

            return result;
        }

        async Task<BookVM?> IBookRepository.FindByIdAsync(int id)
        {
            IQueryable<Book> query = _context.Books.AsNoTracking();
            var book = await query.Select(MethodsHelper.BookToBookVM()).FirstOrDefaultAsync(e => e.Id == id);
            return book;
        }
    }
}
