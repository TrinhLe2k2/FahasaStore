using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.Interfaces;
using FahasaStoreApp.Models.ViewModels;

namespace FahasaStoreApp.Base.Interfaces
{
    public interface IBaseService<TEntity, TViewModel>
        where TEntity : class
        where TViewModel : class, IEntity<int>
    {
        Task<TViewModel> GetByIdAsync(int id);
        Task<TViewModel> CreateAsync(TViewModel model);
        Task<TViewModel> UpdateAsync(int id, TViewModel model);
        Task<bool> DeleteAsync(int id);
        Task<FilterVM<TViewModel>> FilterAsync(FilterOptions filterOptions);
    }
}
