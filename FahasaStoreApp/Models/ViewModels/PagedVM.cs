namespace FahasaStoreApp.Models.ViewModels
{
    public class PagedVM<T>
    {
        public IEnumerable<T> Items { get; set; } = null!;
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

    public class PagedVM2<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }
        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling((double)TotalItemCount / PageSize);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return PageNumber < PageCount;
            }
        }
        public bool HasPreviousPage
        {
            get
            {
                return PageNumber > 1;
            }
        }
        public bool IsFirstPage
        {
            get
            {
                return PageNumber == 1;
            }
        }
        public bool IsLastPage
        {
            get
            {
                return PageNumber == PageCount;
            }
        }
        public int StartPage
        {
            get
            {
                return Math.Max(1, PageNumber - 5);
            }
        }
        public int EndPage
        {
            get
            {
                return Math.Min(PageCount, PageNumber + 4);
            }
        }
    }

}
