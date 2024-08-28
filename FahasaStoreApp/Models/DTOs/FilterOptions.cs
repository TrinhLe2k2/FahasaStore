namespace FahasaStoreApp.Models.DTOs
{
    public class FilterOptions
    {
        public List<FilterItem> Filters { get; set; } = new List<FilterItem>();
        public string SortField { get; set; } = "Id";
        public bool OrderByDescending { get; set; } = true;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class FilterItem
    {
        public string TypeOfKey { get; set; } = "int";
        public string Key { get; set; } = "Id";
        public string? Value { get; set; }
        public string ComparisonOperator { get; set; } = "=";
    }
}
