namespace FahasaStoreApp.Models
{
    public class ViettelPost<T>
    {
        public int Status { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; } = null!;
        public List<T> Data { get; set; } = new List<T>();
    }

    public class Province
    {
        public int? PROVINCE_ID { get; set; }
        public string? PROVINCE_CODE { get; set; }
        public string? PROVINCE_NAME { get; set; }
    }

    public class District
    {
        public int? DISTRICT_ID { get; set; }
        public int? PROVINCE_ID { get; set; }
        public string? DISTRICT_VALUE { get; set; }
        public string? DISTRICT_NAME { get; set; }
    }

    public class Ward
    {
        public int? WARDS_ID { get; set; }
        public int? DISTRICT_ID { get; set; }
        public string? WARDS_NAME { get; set; }
    }
}
