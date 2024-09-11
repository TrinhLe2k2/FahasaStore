using FahasaStore.Models.Interfaces;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.ViewModels;
using X.PagedList;

namespace FahasaStoreAPI.Base.Interfaces
{
    public interface IBaseService<TEntity, TViewModel>
        where TEntity : class
        where TViewModel : class, IEntity
    {
        Task<TViewModel> AddAsync(TViewModel model);
        Task<IEnumerable<TViewModel>> AddRangeAsync(IEnumerable<TViewModel> models);
        Task<TViewModel> UpdateAsync(int id, TViewModel model);
        Task<bool> DeleteAsync(int id);
        Task<TViewModel?> FindByIdAsync(int id);
        Task<FilterVM<TViewModel>> FilterAsync(FilterOptions filterOptions);
    }
}
