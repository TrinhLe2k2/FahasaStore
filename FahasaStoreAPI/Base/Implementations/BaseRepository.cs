using AutoMapper;
using AutoMapper.QueryableExtensions;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Helpers;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.Interfaces;
using FahasaStoreAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using X.PagedList;

namespace FahasaStoreAPI.Base.Implementations
{
    public class BaseRepository<TEntity, TViewModel> : IBaseRepository<TEntity, TViewModel>
        where TEntity : class
        where TViewModel : class, IEntity<int>
    {
        protected readonly FahasaStoreDBContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IMapper _mapper;
        protected readonly IQueryable<TViewModel> _query;

        public BaseRepository(FahasaStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _mapper = mapper;
            _query = _dbSet.AsNoTracking().AsQueryable().ProjectTo<TViewModel>(_mapper.ConfigurationProvider);
        }

        public virtual async Task<TViewModel> AddAsync(TViewModel model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            TViewModel result = _mapper.Map<TViewModel>(entity);
            return await _query.FirstAsync(e => e.Id.Equals(result.Id));
        }

        public virtual async Task<IEnumerable<TViewModel>> AddRangeAsync(IEnumerable<TViewModel> models)
        {
            var entities = _mapper.Map<TEntity>(models);
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return models;
        }

        public virtual async Task<bool> DeleteAsync(TViewModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<FilterVM<TViewModel>> FilterAsync(FilterOptions filterOptions)
        {
            var query = _query;
            if (filterOptions.Filters != null && filterOptions.Filters.Count > 0)
            {
                foreach (var filter in filterOptions.Filters)
                {
                    string key = filter.Key;
                    string? value = filter.Value;
                    string typeOfKey = filter.TypeOfKey;
                    string comparisonOperator = filter.ComparisonOperator;

                    if (!string.IsNullOrEmpty(key) && typeof(TEntity).GetProperty(key) != null && !string.IsNullOrEmpty(value))
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

            if (!string.IsNullOrEmpty(filterOptions.SortField) && typeof(TEntity).GetProperty(filterOptions.SortField) != null)
            {
                query = query.OrderBy($"{filterOptions.SortField} {(filterOptions.OrderByDescending ? "desc" : "asc")}");
            }
            else
            {
                query = query.OrderBy(e => e.Id);
            }

            var pagedList = await query.ToPagedListAsync(filterOptions.PageNumber, filterOptions.PageSize);
            var paged = MethodsHelper.GetPagedAsync<TViewModel>(pagedList);
            var result = new FilterVM<TViewModel>(filterOptions, paged);
            return result;
        }

        public virtual async Task<TViewModel?> FindByIdAsync(int id)
        {
            var result = await _query.FirstOrDefaultAsync(e => e.Id.Equals(id));
            return result;
        }

        public virtual async Task<TViewModel> UpdateAsync(TViewModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await _query.FirstAsync(e => e.Id.Equals(model.Id));
        }
    }
}
