using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController<Book, Book, Book, int>
    {
        private readonly IBookService _bookService;
        public BooksController(IBaseService<Book, Book, Book, int> service, IBookService bookService) : base(service)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult> Details(int id)
        {
            var entity = await _bookService.FindByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost("Filter")]
        public override async Task<ActionResult> Filter(FilterOptions filterOptions)
        {
            var result = await _bookService.FilterAsync(filterOptions);
            return Ok(result);
        }

    }
}
