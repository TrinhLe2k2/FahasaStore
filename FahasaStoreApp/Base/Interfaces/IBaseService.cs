using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreApp.Base.Interfaces
{
    public interface IBaseService<TEntity, TCreateDto, TEditDto, TKey>
        where TEntity : class
        where TCreateDto : class
        where TEditDto : class
        where TKey : IEquatable<TKey>
    {
        Task<TEntity> Details(TKey id);
        Task<TEntity> CreateAsync(TCreateDto dto);
        Task<TEntity> Update(TKey id, TEditDto dto);
        Task<bool> Delete(TKey id);
        Task<FilterVM<TEntity>> Filter(FilterOptions filterOptions);
    }
}
