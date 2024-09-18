using FahasaStore.Models.Interfaces;
using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.ViewModels;
using FahasaStoreApp.Services;
using System.Net.Http;

namespace FahasaStoreApp.Areas.Base
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

        //Extend
        //Task<ApiResponse<TDetail>> AddMultipartAsync(TBase model);
        //Task<ApiResponse<TBase>> UpdateMultipartAsync(int id, TBase model);
    }

    public class BaseService<TEntity, TDetail, TExtend, TBase> : IBaseService<TEntity, TDetail, TExtend, TBase>
        where TEntity : class
        where TDetail : class, TExtend
        where TExtend : class, TBase
        where TBase : class, IEntity
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly IMethodsHelper _methodsHelper;
        protected readonly ICloudinaryService _cloudinaryService;

        public BaseService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService)
        {
            _httpClientFactory = httpClientFactory;
            _methodsHelper = methodsHelper;
            _cloudinaryService = cloudinaryService;
        }

        public virtual async Task<ApiResponse<TDetail>> AddAsync(TBase model)
        {
            model = await _cloudinaryService.UploadImageHandlerAsync(model);
            string endpoint = "/" + typeof(TEntity).Name;
            return await _methodsHelper.RequestHttpPost<ApiResponse<TDetail>, TBase>(_httpClientFactory, endpoint, model);
        }

        public virtual async Task<ApiResponse<string>> DeleteAsync(int id)
        {
            string endpoint = "/" + typeof(TEntity).Name + "/" + id;
            return await _methodsHelper.RequestHttpDelete<ApiResponse<string>>(_httpClientFactory, endpoint);
        }

        public virtual async Task<ApiResponse<FilterVM<TExtend>>> FilterAsync(FilterOptions filterOptions)
        {
            string endpoint = "/" + typeof(TEntity).Name + "/Filter";
            return await _methodsHelper.RequestHttpPost<ApiResponse<FilterVM<TExtend>>, FilterOptions>(_httpClientFactory, endpoint, filterOptions);
        }

        public virtual async Task<ApiResponse<TDetail>> GetByIdAsync(int id)
        {
            string endpoint = "/" + typeof(TEntity).Name + "/" + id;
            return await _methodsHelper.RequestHttpGet<ApiResponse<TDetail>>(_httpClientFactory, endpoint);
        }

        public virtual async Task<ApiResponse<TBase>> UpdateAsync(int id, TBase model)
        {
            model = await _cloudinaryService.UploadImageHandlerAsync(model);
            string endpoint = "/" + typeof(TEntity).Name + "/" + id;
            return await _methodsHelper.RequestHttpPut<ApiResponse<TBase>, TBase>(_httpClientFactory, endpoint, model);
        }

        #region Extend
        //Extend
        //public virtual async Task<ApiResponse<TBase>> UpdateMultipartAsync(int id, TBase model)
        //{
        //    string endpoint = "/" + typeof(TEntity).Name + "/" + id;
        //    return await _methodsHelper.RequestHttpPutMultipart<ApiResponse<TBase>, TBase>(_httpClientFactory, endpoint, model);
        //}
        //public virtual async Task<ApiResponse<TDetail>> AddMultipartAsync(TBase model)
        //{
        //    string endpoint = "/" + typeof(TEntity).Name;
        //    return await _methodsHelper.RequestHttpPostMultipart<ApiResponse<TDetail>, TBase>(_httpClientFactory, endpoint, model);
        //}
        #endregion
    }
}
