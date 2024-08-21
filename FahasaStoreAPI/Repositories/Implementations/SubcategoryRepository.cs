using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Models;
using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FahasaStoreAPI.Repositories.Implementations
{
    public class SubcategoryRepository : BaseRepository<Subcategory, int>, ISubcategoryRepository
    {
        public SubcategoryRepository(FahasaStoreDBContext context) : base(context)
        {
        }

        protected override IQueryable<Subcategory> QueryableForFilterAsync()
        {
            return base.QueryableForFilterAsync();
        }

        protected override IQueryable<Subcategory> QueryableForGetByIdAsync()
        {
            return base.QueryableForGetByIdAsync();
        }
    }
}
