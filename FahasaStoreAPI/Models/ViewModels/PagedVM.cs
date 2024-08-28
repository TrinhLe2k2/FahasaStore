namespace FahasaStoreAPI.Models.ViewModels
{
    public class PagedVM<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public PagedNavigation PagedNavigation { get; set; } = new PagedNavigation();

        //public int PageNumber { get; set; }
        //public int PageSize { get; set; }
        //public int TotalItemCount { get; set; }
        //public int PageCount { get; set; }
        //public bool HasNextPage { get; set; }
        //public bool HasPreviousPage { get; set; }
        //public bool IsFirstPage { get; set; }
        //public bool IsLastPage { get; set; }
        //public int StartPage { get; set; }
        //public int EndPage { get; set; }
    }

    public class PagedNavigation
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }
        public int PageCount { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
    }
}
