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
        protected readonly IMethodsHelper _methodsHelper;

        public BaseService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper)
        {
            _httpClientFactory = httpClientFactory;
            _methodsHelper = methodsHelper;
        }

        public virtual async Task<TViewModel> GetByIdAsync(int id)
        {
            string endpoint = "/" + _methodsHelper.PluralizeWord<TEntity>() + "/" + id;
            return await _methodsHelper.RequestHttpGet<TViewModel>(_httpClientFactory, endpoint);
        }

        public virtual async Task<TViewModel> CreateAsync(TViewModel model)
        {
            string endpoint = "/" + _methodsHelper.PluralizeWord<TEntity>();
            return await _methodsHelper.RequestHttpPost<TViewModel, TViewModel>(_httpClientFactory, endpoint, model);
        }

        public virtual async Task<TViewModel> UpdateAsync(int id, TViewModel model)
        {
            string endpoint = "/" + _methodsHelper.PluralizeWord<TEntity>() + "/" + id;
            return await _methodsHelper.RequestHttpPut<TViewModel, TViewModel>(_httpClientFactory, endpoint, model);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            string endpoint = "/" + _methodsHelper.PluralizeWord<TEntity>()+ "/" + id;
            return await _methodsHelper.RequestHttpDelete<bool>(_httpClientFactory, endpoint);
        }

        public virtual async Task<FilterVM<TViewModel>> FilterAsync(FilterOptions filterOptions)
        {
            string endpoint = "/" + _methodsHelper.PluralizeWord<TEntity>() + "/Filter";
            return await _methodsHelper.RequestHttpPost<FilterVM<TViewModel>, FilterOptions>(_httpClientFactory, endpoint, filterOptions);
        }
    }
}
