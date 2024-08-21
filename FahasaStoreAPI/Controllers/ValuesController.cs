using AutoMapper;
using AutoMapper.QueryableExtensions;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly FahasaStoreDBContext _context;
        private readonly IMapper _mapper;

        public ValuesController(FahasaStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = _context.Categories.AsNoTracking().AsQueryable();

            var mappedQuery = query.ProjectTo<CategoryVM>(_mapper.ConfigurationProvider);

            return Ok(await mappedQuery.Take(5).ToListAsync());
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AValuesController : TestController<Category, CategoryVM, int>
    {
        public AValuesController(ItestService<Category, CategoryVM, int> service) : base(service)
        {
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AValues2Controller : TestController<Book, BookVM, int>
    {
        public AValues2Controller(ItestService<Book, BookVM, int> service) : base(service)
        {
        }
    }

    public class CategoryVM
    {
        public CategoryVM()
        {
            Subcategories = new HashSet<Subcategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public int CountSubcategories { get; set; } = 0;

        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
