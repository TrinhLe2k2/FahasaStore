using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using X.PagedList;

namespace FahasaStoreAPI.Base.Interfaces
{
    public interface IBaseService<TEntity, TCreateDto, TEditDto, TKey> 
        where TEntity : class
        where TCreateDto : class
        where TEditDto : class
        where TKey : IEquatable<TKey>
    {
        Task<TEntity> AddAsync(TCreateDto TDto);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TCreateDto> dtos);
        Task<TEntity> UpdateAsync(TKey id, TEditDto TDto);
        Task<bool> DeleteAsync(TKey id);
        Task<TEntity?> FindByIdAsync(TKey id);
        Task<TEntity?> FindByIdHaveListAsync(TKey id, List<AttributeCollection> attributeCollection);
        Task<bool> ExistsAsync(TKey id);
        Task<FilterVM<TEntity>> FilterAsync(FilterOptions filterOptions);
    }
}
