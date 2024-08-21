using AutoMapper;
using AutoMapper.QueryableExtensions;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Controllers;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using X.PagedList;

namespace FahasaStoreAPI
{
    public interface ItestRepository<TEntity, TViewModel, TKey>
        where TEntity : class, IEntity<TKey>
        where TViewModel : class
        where TKey : IEquatable<TKey>
    {
        Task<List<TViewModel>> FilterAsync();
    }

    public class testRepository<TEntity, TViewModel, TKey> : ItestRepository<TEntity, TViewModel, TKey>
        where TEntity : class, IEntity<TKey>
        where TViewModel : class
        where TKey : IEquatable<TKey>
    {
        protected readonly FahasaStoreDBContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IMapper _mapper;

        public testRepository(FahasaStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<List<TViewModel>> FilterAsync()
        {
            var query = _dbSet.AsNoTracking().AsQueryable();
            var mappedQuery = query.ProjectTo<TViewModel>(_mapper.ConfigurationProvider);

            return await mappedQuery.Take(5).ToListAsync();
        }
    }

    public interface ItestService<TEntity, TViewModel, TKey>
        where TEntity : class, IEntity<TKey>
        where TViewModel : class
        where TKey : IEquatable<TKey>
    {
        Task<List<TViewModel>> FilterAsync();
    }

    public class testService<TEntity, TViewModel, TKey> : ItestService<TEntity, TViewModel, TKey>
        where TEntity : class, IEntity<TKey>
        where TViewModel : class
        where TKey : IEquatable<TKey>
    {
        private readonly ItestRepository<TEntity, TViewModel, TKey> _itestRepository;

        public testService(ItestRepository<TEntity, TViewModel, TKey> itestRepository)
        {
            _itestRepository = itestRepository;
        }

        public async Task<List<TViewModel>> FilterAsync()
        {
            return await _itestRepository.FilterAsync();
        }
    }

    public abstract class TestController<TEntity, TViewModel, TKey> : ControllerBase
        where TEntity : class, IEntity<TKey>
        where TViewModel : class
        where TKey : IEquatable<TKey>
    {
        protected readonly ItestService<TEntity, TViewModel, TKey> _service;

        protected TestController(ItestService<TEntity, TViewModel, TKey> service)
        {
            _service = service;
        }

        [HttpGet("test")]
        public virtual async Task<ActionResult> test()
        {
            var entity = await _service.FilterAsync();
            return Ok(entity);
        }
    }
}
