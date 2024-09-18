using AutoMapper;
using AutoMapper.QueryableExtensions;
using FahasaStore.Models.Interfaces;
using FahasaStoreAPI.Helpers;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using X.PagedList;

namespace FahasaStoreAPI.Areas.Base
{
    public interface IAdminBaseRepository<TEntity, TDetail, TExtend, TBase>
        where TEntity : class
        where TDetail : class, TExtend
        where TExtend : class, TBase
        where TBase : class, IEntity
    {
        Task<TDetail> GetByIdAsync(int id);
        Task<TDetail> AddAsync(TBase model);
        Task UpdateAsync(TBase model);
        Task DeleteAsync(int id);
        Task<FilterVM<TExtend>> FilterAsync(FilterOptions filterOptions);
    }

    public class AdminBaseRepository<TEntity, TDetail, TExtend, TBase> : IAdminBaseRepository<TEntity, TDetail, TExtend, TBase>
        where TEntity : class
        where TDetail : class, TExtend
        where TExtend : class, TBase
        where TBase : class, IEntity
    {
        protected readonly FahasaStoreDBContext _context;
        protected readonly IMapper _mapper;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly ICloudinaryService _cloudinaryService;

        public AdminBaseRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = _context.Set<TEntity>();
            _cloudinaryService = cloudinaryService;
        }

        private async Task<TBase> UploadImageHandlerAsync(TBase model)
        {
            var typeOfFile = typeof(TBase).GetProperty("File");
            var typeOfPublicId = typeof(TBase).GetProperty("PublicId");
            var typeOfImageUrl = typeof(TBase).GetProperty("ImageUrl");

            if (typeOfFile != null && typeOfPublicId != null && typeOfImageUrl != null)
            {
                var value = typeOfFile.GetValue(model) as IFormFile;
                var valuePublicId = typeOfPublicId.GetValue(model) as string;
                if (value != null)
                {
                    var responseCloudinary = await _cloudinaryService.UploadImageAsync(value, typeof(TEntity).Name);
                    if (responseCloudinary != null)
                    {
                        typeOfPublicId.SetValue(model, responseCloudinary.PublicId);
                        typeOfImageUrl.SetValue(model, responseCloudinary.ImageUrl);

                        await RemoveImageHandlerAsync(valuePublicId);
                    }
                }
            }
            return model;
        }

        private async Task<bool> RemoveImageHandlerAsync(string? publicId)
        {
            var responseCloudinary = await _cloudinaryService.RemoveImageAsync(publicId);
            return responseCloudinary;
        }

        public virtual async Task<TDetail> GetByIdAsync(int id)
        {
            var result = await _dbSet.AsNoTracking().AsQueryable()
                .ProjectTo<TDetail>(_mapper.ConfigurationProvider)
                .FirstAsync(e => e.Id == id);
            return result;
        }

        public virtual async Task<TDetail> AddAsync(TBase model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<TDetail>(entity);
        }

        public virtual async Task UpdateAsync(TBase model)
        {
            model.CreatedAt = DateTime.Now;
            var entity = _mapper.Map<TEntity>(model);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _dbSet
                .ProjectTo<TBase>(_mapper.ConfigurationProvider)
                .FirstAsync(e => e.Id == id);

            var typeOfPublicId = typeof(TBase).GetProperty("PublicId");
            if (typeOfPublicId != null)
            {
                var valuePublicId = typeOfPublicId.GetValue(entity) as string;
                await RemoveImageHandlerAsync(valuePublicId);
            }

            _dbSet.Remove(_mapper.Map<TEntity>(entity));
            await _context.SaveChangesAsync();
        }

        public virtual IQueryable<TExtend> QueryForFilter()
        {
            var query = _dbSet.AsNoTracking().AsQueryable().ProjectTo<TExtend>(_mapper.ConfigurationProvider);
            return query;
        }

        public virtual async Task<FilterVM<TExtend>> FilterAsync(FilterOptions filterOptions)
        {
            //var query = _dbSet.AsNoTracking().AsQueryable()
            //    .ProjectTo<TExtend>(_mapper.ConfigurationProvider);

            var query = QueryForFilter();

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