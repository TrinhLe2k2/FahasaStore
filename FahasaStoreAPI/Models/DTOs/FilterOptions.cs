namespace FahasaStoreAPI.Models.DTOs
{
    public class FilterOptions
    {
        public List<AttributeCollection> AttributeCollectionInclude { get; set; } = new List<AttributeCollection>();
        public List<FilterItem> Filters { get; set; } = new List<FilterItem>();
        public string SortField { get; set; } = "Id";
        public bool OrderByDescending { get; set; } = true;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 1;
    }

    public class FilterItem
    {
        public string TypeOfKey { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string ComparisonOperator { get; set; } = string.Empty;
    }
}
