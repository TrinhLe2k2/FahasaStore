using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models.ViewModels;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Base.Interfaces;
using FahasaStoreApp.Models.Interfaces;

namespace FahasaStoreApp.Base.Implementations
{
    public class BaseService<TEntity, TViewModel> : IBaseService<TEntity, TViewModel>
        where TEntity : class
        where TViewModel : class, IEntity<int>
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly UserLogined _userLogined;
        protected readonly string _api;

        public BaseService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
        {
            _httpClientFactory = httpClientFactory;
            _userLogined = userLogined;
            _api = $"https://localhost:7094/api/{MethodsHelper.PluralizeWord<TEntity>()}";
        }

        public virtual async Task<TViewModel> GetByIdAsync(int id)
        {
            return await MethodsHelper.RequestHttpGet<TViewModel>(_httpClientFactory, _userLogined, _api + "/" + id);
        }

        public virtual async Task<TViewModel> CreateAsync(TViewModel model)
        {
            return await MethodsHelper.RequestHttpPost<TViewModel, TViewModel>(_httpClientFactory, _userLogined, _api, model);
        }

        public virtual async Task<TViewModel> UpdateAsync(int id, TViewModel model)
        {
            return await MethodsHelper.RequestHttpPut<TViewModel>(_httpClientFactory, _userLogined, _api + "/" + id, model);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await MethodsHelper.RequestHttpDelete(_httpClientFactory, _userLogined, _api + "/" + id);
        }

        public virtual async Task<FilterVM<TViewModel>> FilterAsync(FilterOptions filterOptions)
        {
            return await MethodsHelper.RequestHttpPost<FilterVM<TViewModel>, FilterOptions>(_httpClientFactory, _userLogined, _api + "/Filter", filterOptions);
        }
    }
}
