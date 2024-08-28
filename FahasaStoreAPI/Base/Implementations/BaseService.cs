using AutoMapper;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.Interfaces;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Services.Extensions;
using Humanizer;
using X.PagedList;

namespace FahasaStoreAPI.Base.Implementations
{
    public class BaseService<TEntity, TViewModel> : IBaseService<TEntity, TViewModel>
        where TEntity : class
        where TViewModel : class, IEntity<int>
    {
        protected readonly IBaseRepository<TEntity, TViewModel> _repository;
        protected readonly IMapper _mapper;
        protected readonly ICloudinaryService _cloudinaryService;

        public BaseService(IBaseRepository<TEntity, TViewModel> repository, IMapper mapper, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }

        public virtual async Task<TViewModel> AddAsync(TViewModel model)
        {
            return await _repository.AddAsync(model);
        }

        public virtual async Task<IEnumerable<TViewModel>> AddRangeAsync(IEnumerable<TViewModel> models)
        {
            return await _repository.AddRangeAsync(models);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.FindByIdAsync(id);
            if (entity != null)
            {
                return await _repository.DeleteAsync(entity);
            }
            else
            {
                return false;
            }
        }

        public virtual async Task<FilterVM<TViewModel>> FilterAsync(FilterOptions filterOptions)
        {
            return await _repository.FilterAsync(filterOptions);
        }

        public virtual async Task<TViewModel?> FindByIdAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public virtual async Task<TViewModel> UpdateAsync(int id, TViewModel model)
        {
            if (model.Id.Equals(id) && await _repository.FindByIdAsync(id) != null)
            {
                return await _repository.UpdateAsync(model);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
