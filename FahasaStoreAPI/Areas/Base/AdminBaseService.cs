using FahasaStore.Models;
using FahasaStore.Models.Interfaces;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FahasaStoreAPI.Areas.Base
{
    public interface IAdminBaseService<TEntity, TDetail, TExtend, TBase>
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
    public class AdminBaseService<TEntity, TDetail, TExtend, TBase> : IAdminBaseService<TEntity, TDetail, TExtend, TBase>
        where TEntity : class
        where TDetail : class, TExtend
        where TExtend : class, TBase
        where TBase : class, IEntity
    {
        protected readonly IAdminBaseRepository<TEntity, TDetail, TExtend, TBase> _adminBaseRepository;

        public AdminBaseService(IAdminBaseRepository<TEntity, TDetail, TExtend, TBase> adminBaseRepository)
        {
            _adminBaseRepository = adminBaseRepository;
        }

        public virtual async Task<ApiResponse<TDetail>> GetByIdAsync(int id)
        {
            try
            {
                var detail = await _adminBaseRepository.GetByIdAsync(id);
                return new ApiResponse<TDetail>(status: 200, error: false, message: "Success", data: detail);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TDetail>(status: 500, error: true, message: ex.Message, data: null);
            }
        }

        public virtual async Task<ApiResponse<TDetail>> AddAsync(TBase model)
        {
            try
            {
                var result = await _adminBaseRepository.AddAsync(model);
                return new ApiResponse<TDetail>(status: 200, error: false, message: "Added successfully", data: result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TDetail>(status: 500, error: true, message: ex.Message, data: null);
            }
        }

        public virtual async Task<ApiResponse<TBase>> UpdateAsync(int id, TBase model)
        {
            try
            {
                if (!model.Id.Equals(id))
                {
                    return new ApiResponse<TBase>(status: 500, error: true, message: "Update failed", data: null);
                }
                await _adminBaseRepository.UpdateAsync(model);
                return new ApiResponse<TBase>(status: 200, error: false, message: "Updated successfully", data: model);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TBase>(status: 500, error: true, message: ex.Message, data: null);
            }
        }

        public virtual async Task<ApiResponse<string>> DeleteAsync(int id)
        {
            try
            {
                await _adminBaseRepository.DeleteAsync(id);
                return new ApiResponse<string>(status: 200, error: false, message: "Deleted successfully", data: id.ToString());
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>(status: 500, error: true, message: ex.Message, data: null);
            }
        }

        public virtual async Task<ApiResponse<FilterVM<TExtend>>> FilterAsync(FilterOptions filterOptions)
        {
            try
            {
                var filtered = await _adminBaseRepository.FilterAsync(filterOptions);
                return new ApiResponse<FilterVM<TExtend>>(status: 200, error: false, message: "Filtered successfully", data: filtered);
            }
            catch (Exception ex)
            {
                return new ApiResponse<FilterVM<TExtend>>(status: 500, error: true, message: ex.Message, data: null);
            }
        }
    }
}