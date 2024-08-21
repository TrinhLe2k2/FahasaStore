using AutoMapper;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Services.Extensions;
using Humanizer;
using X.PagedList;

namespace FahasaStoreAPI.Base.Implementations
{
    public class BaseService<TEntity, TCreateDto, TEditDto, TKey> : IBaseService<TEntity, TCreateDto, TEditDto, TKey>
    where TEntity : class
    where TCreateDto : class
    where TEditDto : class
    where TKey : IEquatable<TKey>
    {
        protected readonly IBaseRepository<TEntity, TKey> _repository;
        protected readonly IMapper _mapper;
        protected readonly ICloudinaryService _cloudinaryService;

        public BaseService(IBaseRepository<TEntity, TKey> repository, IMapper mapper, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<TEntity> AddAsync(TCreateDto dto)
        {
            var imageProperty = dto.GetType().GetProperty("image");
            TEntity entity = _mapper.Map<TEntity>(dto);

            if (imageProperty != null && imageProperty.PropertyType == typeof(IFormFile))
            {
                var image = (IFormFile?)imageProperty.GetValue(dto);
                var imageUrlProperty = entity.GetType().GetProperty("ImageUrl");
                var publicIdProperty = entity.GetType().GetProperty("PublicId");

                if (imageUrlProperty != null && publicIdProperty != null)
                {
                    if (image != null)
                    {
                        if (imageUrlProperty != null && publicIdProperty != null)
                        {
                            var cloudinaryResult = await _cloudinaryService.UploadImageAsync(image, typeof(TEntity).Name);
                            imageUrlProperty.SetValue(entity, cloudinaryResult.ImageUrl);
                            publicIdProperty.SetValue(entity, cloudinaryResult.PublicId);
                        }
                    }
                    else
                    {
                        imageUrlProperty.SetValue(entity, "https://cdn11.bigcommerce.com/s-1e8n54ohum/stencil/aeed8ad0-46d5-0138-f017-0242ac110004/icons/icon-no-image.svg");
                        publicIdProperty.SetValue(entity, null);
                    }
                }
                
            }
            return await _repository.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TCreateDto> dtos)
        {
            IEnumerable<TEntity> entities = _mapper.Map<IEnumerable<TEntity>>(dtos);
            return await _repository.AddRangeAsync(entities);
        }

        public async Task<TEntity> UpdateAsync(TKey id, TEditDto dto)
        {
            var entity = await _repository.FindByIdAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }

            var imageProperty = dto.GetType().GetProperty("image");

            if (imageProperty != null && imageProperty.PropertyType == typeof(IFormFile))
            {
                var entityPublicIdProperty = typeof(TEntity).GetProperty("PublicId");
                if (entityPublicIdProperty != null)
                {
                    var currentPublicId = (string?)entityPublicIdProperty.GetValue(entity);
                    if (!string.IsNullOrEmpty(currentPublicId))
                    {
                        await _cloudinaryService.RemoveImageAsync(currentPublicId);
                    }
                }

                var image = (IFormFile?)imageProperty.GetValue(dto);
                if (image != null)
                {
                    var imageUrlProperty = entity.GetType().GetProperty("ImageUrl");
                    var publicIdProperty = entity.GetType().GetProperty("PublicId");
                    if (imageUrlProperty != null && publicIdProperty != null)
                    {
                        var cloudinaryResult = await _cloudinaryService.UploadImageAsync(image, typeof(TEntity).Name);
                        imageUrlProperty.SetValue(entity, cloudinaryResult.ImageUrl);
                        publicIdProperty.SetValue(entity, cloudinaryResult.PublicId);
                    }
                }
            }

            _mapper.Map(dto, entity);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            TEntity? entity = await _repository.FindByIdAsync(id);
            if (entity != null)
            {
                return await _repository.DeleteAsync(entity);
            }
            else
            {
                return false;
            }
        }

        public async Task<TEntity?> FindByIdAsync(TKey id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<TEntity?> FindByIdHaveListAsync(TKey id, List<AttributeCollection> attributeCollection)
        {
            return await _repository.FindByIdHaveListAsync(id, attributeCollection);
        }

        public async Task<bool> ExistsAsync(TKey id)
        {
            return await _repository.ExistsAsync(id);
        }

        public async Task<FilterVM<TEntity>> FilterAsync(FilterOptions filterOptions)
        {
            IPagedList<TEntity> pagedList = await _repository.FilterAsync(filterOptions);
            var paged = GetPagedAsync(pagedList);
            var result = new FilterVM<TEntity>(filterOptions, paged);
            return result;
        }

        private PagedVM<TEntity> GetPagedAsync(IPagedList<TEntity> pagedList)
        {
            int maxPages = 5;
            int totalPages = pagedList.PageCount;
            int pageNumber = pagedList.PageNumber;

            int startPage = Math.Max(1, pageNumber - maxPages / 2);
            if (startPage + maxPages - 1 > totalPages)
            {
                startPage = Math.Max(1, totalPages - maxPages + 1);
            }

            int endPage = Math.Min(totalPages, pageNumber + maxPages / 2);
            if (endPage < maxPages)
            {
                endPage = Math.Min(totalPages, maxPages);
            }

            return new PagedVM<TEntity>
            {
                Items = pagedList.ToList(),
                PageNumber = pagedList.PageNumber,
                PageSize = pagedList.PageSize,
                TotalItemCount = pagedList.TotalItemCount,
                PageCount = pagedList.PageCount,
                HasNextPage = pagedList.HasNextPage,
                HasPreviousPage = pagedList.HasPreviousPage,
                IsFirstPage = pagedList.IsFirstPage,
                IsLastPage = pagedList.IsLastPage,
                StartPage = startPage,
                EndPage = endPage
            };
        }
    }

}
