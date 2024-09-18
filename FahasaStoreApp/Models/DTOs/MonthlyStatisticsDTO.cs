namespace FahasaStoreApp.Models.DTOs
{
    public class MonthlyStatisticsDTO
    {
        public int Year { get; set; } = 0;
        public int Month { get; set; } = 0;
        public int NotCompletedOrdersCount { get; set; } = 0;
        public int ShippedOrdersCount { get; set; } = 0;
        public int CompletedOrdersCount { get; set; } = 0;
        public int CancelledOrdersCount { get; set; } = 0;
        public int ReturnedOrdersCount { get; set; } = 0;
        public int OrdersCount { get; set; } = 0;

        public int NewUsersInMonthCount { get; set; } = 0;
        public int TotalBooksSold { get; set; } = 0;
        public int TotalRevenue { get; set; } = 0;
    }
}
