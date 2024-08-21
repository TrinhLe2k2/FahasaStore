using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Models.ViewModels.Entities;

namespace FahasaStoreAPI.Services.Interfaces
{
    public interface IBookService : IBaseService<Book, BookCreateDto, BookEditDto, int>
    {
        new Task<BookVM?> FindByIdAsync(int id);
        new Task<FilterVM<BookVM>> FilterAsync(FilterOptions filterOptions);
    }
}
