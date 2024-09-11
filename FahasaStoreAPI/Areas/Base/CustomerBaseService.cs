using FahasaStore.Models;
using FahasaStore.Models.Interfaces;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FahasaStoreAPI.Areas.Base
{
    public interface ICustomerBaseService<TEntity, TDetail, TExtend, TBase>
        where TEntity : class
        where TDetail : class, TExtend
        where TExtend : class, TBase
        where TBase : class, IEntity, IUserModel
    {
        Task<ApiResponse<TDetail>> GetByIdAsync(int id, int userId);
        Task<ApiResponse<TDetail>> AddAsync(TBase model, int userId);
        Task<ApiResponse<TBase>> UpdateAsync(int id, TBase model, int userId);
        Task<ApiResponse<string>> DeleteAsync(int id, int userId);
        Task<ApiResponse<FilterVM<TExtend>>> FilterAsync(FilterOptions filterOptions, int userId);
    }
    public class CustomerBaseService<TEntity, TDetail, TExtend, TBase> : ICustomerBaseService<TEntity, TDetail, TExtend, TBase>
        where TEntity : class
        where TDetail : class, TExtend
        where TExtend : class, TBase
        where TBase : class, IEntity, IUserModel
    {
        protected readonly ICustomerBaseRepository<TEntity, TDetail, TExtend, TBase> _customerBaseRepository;

        public CustomerBaseService(ICustomerBaseRepository<TEntity, TDetail, TExtend, TBase> customerBaseRepository)
        {
            _customerBaseRepository = customerBaseRepository;
        }

        public virtual async Task<ApiResponse<TDetail>> GetByIdAsync(int id, int userId)
        {
            try
            {
                var detail = await _customerBaseRepository.GetByIdAsync(id, userId);
                return new ApiResponse<TDetail>(status: 200, error: false, message: "Success", data: detail);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TDetail>(status: 500, error: true, message: ex.Message, data: null);
            }
        }

        public virtual async Task<ApiResponse<TDetail>> AddAsync(TBase model, int userId)
        {
            try
            {
                var result = await _customerBaseRepository.AddAsync(model, userId);
                return new ApiResponse<TDetail>(status: 200, error: false, message: "Added successfully", data: result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TDetail>(status: 500, error: true, message: ex.Message, data: null);
            }
        }

        public virtual async Task<ApiResponse<TBase>> UpdateAsync(int id, TBase model, int userId)
        {
            try
            {
                if (!model.Id.Equals(id) || !model.UserId.Equals(userId))
                {
                    return new ApiResponse<TBase>(status: 500, error: true, message: "Update failed", data: null);
                }
                await _customerBaseRepository.UpdateAsync(model);
                return new ApiResponse<TBase>(status: 200, error: false, message: "Updated successfully", data: model);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TBase>(status: 500, error: true, message: ex.Message, data: null);
            }
        }

        public virtual async Task<ApiResponse<string>> DeleteAsync(int id, int userId)
        {
            try
            {
                await _customerBaseRepository.DeleteAsync(id, userId);
                return new ApiResponse<string>(status: 200, error: false, message: "Deleted successfully", data: id.ToString());
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>(status: 500, error: true, message: ex.Message, data: null);
            }
        }

        public virtual async Task<ApiResponse<FilterVM<TExtend>>> FilterAsync(FilterOptions filterOptions, int userId)
        {
            try
            {
                var filtered = await _customerBaseRepository.FilterAsync(filterOptions, userId);
                return new ApiResponse<FilterVM<TExtend>>(status: 200, error: false, message: "Filtered successfully", data: filtered);
            }
            catch (Exception ex)
            {
                return new ApiResponse<FilterVM<TExtend>>(status: 500, error: true, message: ex.Message, data: null);
            }
        }
    }
}
