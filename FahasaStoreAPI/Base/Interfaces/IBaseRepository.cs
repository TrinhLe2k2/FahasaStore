using FahasaStore.Models.Interfaces;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.ViewModels;

namespace FahasaStoreAPI.Base.Interfaces
{
    public interface IBaseRepository<TEntity, TViewModel> 
        where TEntity : class
        where TViewModel : class, IEntity
    {
        Task<TViewModel?> FindByIdAsync(int id);
        Task<TViewModel> AddAsync(TViewModel model);
        Task<IEnumerable<TViewModel>> AddRangeAsync(IEnumerable<TViewModel> models);
        Task<TViewModel> UpdateAsync(TViewModel model);
        Task<bool> DeleteAsync(TViewModel model);
        Task<FilterVM<TViewModel>> FilterAsync(FilterOptions filterOptions);
    }
}
