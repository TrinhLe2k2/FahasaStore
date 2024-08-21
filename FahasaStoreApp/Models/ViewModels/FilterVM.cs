using FahasaStoreApp.Models.DTOs;

namespace FahasaStoreApp.Models.ViewModels
{
    public class FilterVM<T>
    {
        public FilterVM()
        {
            FilterOptions = new FilterOptions();
            Paged = new PagedVM<T>();
        }
        public FilterVM(FilterOptions filterOptions, PagedVM<T> paged)
        {
            FilterOptions = filterOptions;
            Paged = paged;
        }

        public FilterOptions FilterOptions { get; set; }
        public PagedVM<T> Paged { get; set; } = null!;
    }
}
