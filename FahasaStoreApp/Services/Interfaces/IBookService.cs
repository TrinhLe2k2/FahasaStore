using FahasaStoreAPI.Models.Entities;
using FahasaStoreApp.Base.Interfaces;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.ViewModels;
using FahasaStoreApp.Models.ViewModels.Entities;

namespace FahasaStoreApp.Services.Interfaces
{
    public interface IBookService : IBaseService<Book, Book, Book, int>
    {
        new Task<BookVM?> Details(int id);
        new Task<FilterVM<BookVM>> Filter(FilterOptions filterOptions);
    }
}
