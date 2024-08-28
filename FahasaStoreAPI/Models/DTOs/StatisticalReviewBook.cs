namespace FahasaStoreAPI.Models.DTOs
{
    public class StatisticalReviewBook
    {
        public double RateAverage { get; set; } = 0;
        public int RateCount { get; set; } = 0;

        public int Rate1Percentage { get; set; } = 0;
        public int Rate2Percentage { get; set; } = 123;
        public int Rate3Percentage { get; set; } = 0;
        public int Rate4Percentage { get; set; } = 0;
        public int Rate5Percentage { get; set; } = 0;
    }
}
