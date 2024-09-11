using AutoMapper;
using AutoMapper.QueryableExtensions;
using FahasaStore.Models.Interfaces;
using FahasaStoreAPI.Helpers;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using X.PagedList;

namespace FahasaStoreAPI.Areas.Base
{
    public interface ICustomerBaseRepository<TEntity, TDetail, TExtend, TBase>
        where TEntity : class
        where TDetail : class, TExtend
        where TExtend : class, TBase
        where TBase : class, IEntity, IUserModel
    {
        Task<TDetail> GetByIdAsync(int id, int userId);
        Task<TDetail> AddAsync(TBase model, int userId);
        Task UpdateAsync(TBase model);
        Task DeleteAsync(int id, int userId);
        Task<FilterVM<TExtend>> FilterAsync(FilterOptions filterOptions, int userId);
    }

    public class CustomerBaseRepository<TEntity, TDetail, TExtend, TBase> : ICustomerBaseRepository<TEntity, TDetail, TExtend, TBase>
        where TEntity : class
        where TDetail : class, TExtend
        where TExtend : class, TBase
        where TBase : class, IEntity, IUserModel
    {
        protected readonly FahasaStoreDBContext _context;
        protected readonly IMapper _mapper;
        protected readonly DbSet<TEntity> _dbSet;

        public CustomerBaseRepository(FahasaStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TDetail> GetByIdAsync(int id, int userId)
        {
            var result = await _dbSet.AsNoTracking().AsQueryable()
                .ProjectTo<TDetail>(_mapper.ConfigurationProvider)
                .FirstAsync(e => e.Id == id && e.UserId == userId);
            return result;
        }

        public virtual async Task<TDetail> AddAsync(TBase model, int userId)
        {
            model.UserId = userId;
            TEntity entity = _mapper.Map<TEntity>(model);
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<TDetail>(entity);
        }

        //_dbSet.Update(entity);
        //await _context.SaveChangesAsync();
        public virtual async Task UpdateAsync(TBase model)
        {
            model.CreatedAt = DateTime.Now;
            var entity = _mapper.Map<TEntity>(model);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id, int userId)
        {
            var entity = await _dbSet
                .ProjectTo<TBase>(_mapper.ConfigurationProvider)
                .FirstAsync(e => e.Id == id && e.UserId == userId);

            _dbSet.Remove(_mapper.Map<TEntity>(entity));
            await _context.SaveChangesAsync();
        }

        public virtual async Task<FilterVM<TExtend>> FilterAsync(FilterOptions filterOptions, int userId)
        {
            var query = _dbSet.AsNoTracking().AsQueryable()
                .ProjectTo<TExtend>(_mapper.ConfigurationProvider)
                .Where(e => e.UserId == userId);

            if (filterOptions.IntIds.Any())
            {
                query = query.Where(e => filterOptions.IntIds.Contains(e.Id));
            }

            if (filterOptions.Filters != null && filterOptions.Filters.Count > 0)
            {
                foreach (var filter in filterOptions.Filters)
                {
                    string key = filter.Key;
                    string? value = filter.Value;
                    string typeOfKey = filter.TypeOfKey;
                    string comparisonOperator = filter.ComparisonOperator;

                    if (!string.IsNullOrEmpty(key) && typeof(TExtend).GetProperty(key) != null && !string.IsNullOrEmpty(value))
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
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(filterOptions.SortField) && typeof(TExtend).GetProperty(filterOptions.SortField) != null)
            {
                query = query.OrderBy($"{filterOptions.SortField} {(filterOptions.OrderByDescending ? "desc" : "asc")}");
            }
            else
            {
                query = query.OrderByDescending(e => e.Id);
            }

            var pagedList = await query.ToPagedListAsync(filterOptions.PageNumber, filterOptions.PageSize);
            var paged = MethodsHelper.GetPaged(pagedList);
            var result = new FilterVM<TExtend>(filterOptions, paged);
            return result;
        }
    }
}
