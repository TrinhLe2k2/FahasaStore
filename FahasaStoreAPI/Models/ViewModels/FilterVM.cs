using FahasaStoreAPI.Models.DTOs;

namespace FahasaStoreAPI.Models.ViewModels
{
    public class FilterVM<T>
    {
        public FilterVM(FilterOptions? filterOptions, PagedVM<T> paged)
        {
            FilterOptions = filterOptions;
            Paged = paged;
        }

        public FilterOptions? FilterOptions { get; set; }
        public PagedVM<T> Paged { get; set; } = null!;
    }
}
