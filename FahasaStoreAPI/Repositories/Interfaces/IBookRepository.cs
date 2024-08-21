using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels.Entities;
using System.ComponentModel;
using X.PagedList;

namespace FahasaStoreAPI.Repositories.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book, int>
    {
        new Task<BookVM?> FindByIdAsync(int id);
        new Task<IPagedList<BookVM>> FilterAsync(FilterOptions filterOptions);
    }
}
