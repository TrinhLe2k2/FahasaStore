using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using X.PagedList;

namespace FahasaStoreAPI.Base.Interfaces
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class where TKey : IEquatable<TKey>
    {
        Task<TEntity?> FindByIdAsync(TKey id);
        Task<TEntity?> FindByIdHaveListAsync(TKey id, List<AttributeCollection> attributeCollection);
        Task<TEntity> AddAsync(TEntity tEntity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity tEntity);
        Task<bool> DeleteAsync(TEntity tEntity);
        Task<bool> ExistsAsync(TKey id);
        Task<IPagedList<TEntity>> FilterAsync(FilterOptions filterOptions);
    }
}
