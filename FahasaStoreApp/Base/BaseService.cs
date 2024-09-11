using FahasaStore.Models.Interfaces;
using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.ViewModels;
using System.Net.Http;

namespace FahasaStoreApp.Base
{
    public interface IBaseService<TEntity, TDetail, TExtend, TBase>
        where TEntity : class
        where TDetail : class, TExtend
        where TExtend : class, TBase
        where TBase : class, IEntity
    {
        Task<ApiResponse<TDetail>> GetByIdAsync(int id);
        Task<ApiResponse<TDetail>> AddAsync(TBase model);
        Task<ApiResponse<TBase>> UpdateAsync(int id, TBase model);
        Task<ApiResponse<string>> DeleteAsync(int id);
        Task<ApiResponse<FilterVM<TExtend>>> FilterAsync(FilterOptions filterOptions);
    }

    public class BaseService<TEntity, TDetail, TExtend, TBase> : IBaseService<TEntity, TDetail, TExtend, TBase>
        where TEntity : class
        where TDetail : class, TExtend
        where TExtend : class, TBase
        where TBase : class, IEntity
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly IMethodsHelper _methodsHelper;

        public BaseService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper)
        {
            _httpClientFactory = httpClientFactory;
            _methodsHelper = methodsHelper;
        }

        public virtual async Task<ApiResponse<TDetail>> AddAsync(TBase model)
        {
            string endpoint = "/" + _methodsHelper.PluralizeWord<TEntity>();
            return await _methodsHelper.RequestHttpPost<ApiResponse<TDetail>, TBase>(_httpClientFactory, endpoint, model);
        }

        public virtual async Task<ApiResponse<string>> DeleteAsync(int id)
        {
            string endpoint = "/" + _methodsHelper.PluralizeWord<TEntity>() + "/" + id;
            return await _methodsHelper.RequestHttpDelete<ApiResponse<string>>(_httpClientFactory, endpoint);
        }

        public virtual async Task<ApiResponse<FilterVM<TExtend>>> FilterAsync(FilterOptions filterOptions)
        {
            string endpoint = "/" + _methodsHelper.PluralizeWord<TEntity>() + "/Filter";
            return await _methodsHelper.RequestHttpPost<ApiResponse<FilterVM<TExtend>>, FilterOptions>(_httpClientFactory, endpoint, filterOptions);
        }

        public virtual async Task<ApiResponse<TDetail>> GetByIdAsync(int id)
        {
            string endpoint = "/" + _methodsHelper.PluralizeWord<TEntity>() + "/" + id;
            return await _methodsHelper.RequestHttpGet<ApiResponse<TDetail>>(_httpClientFactory, endpoint);
        }

        public virtual async Task<ApiResponse<TBase>> UpdateAsync(int id, TBase model)
        {
            string endpoint = "/" + _methodsHelper.PluralizeWord<TEntity>() + "/" + id;
            return await _methodsHelper.RequestHttpPut<ApiResponse<TBase>, TBase>(_httpClientFactory, endpoint, model);
        }
    }
}
