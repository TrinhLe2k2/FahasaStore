using AutoMapper;
using AutoMapper.QueryableExtensions;
using FahasaStore.Models;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace FahasaStoreAPI.Areas.Admin
{
    public interface IAdminExtendRepository
    {
        Task<IEnumerable<MonthlyStatisticsDTO>> GetYearlyStatisticsAsync(int? year);
    }
    public class AdminExtendRepository : IAdminExtendRepository
    {
        private readonly FahasaStoreDBContext _context;
        private readonly IMapper _mapper;

        public AdminExtendRepository(FahasaStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MonthlyStatisticsDTO>> GetYearlyStatisticsAsync(int? year)
        {
            var statistics = new List<MonthlyStatisticsDTO>();
            int targetYear = year ?? DateTime.Now.Year;
            int currentMonth = targetYear == DateTime.Now.Year ? DateTime.Now.Month : 12;

            for (int month = 1; month <= currentMonth; month++)
            {
                var startDate = new DateTime(targetYear, month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                var query = _context.Orders.AsNoTracking()
                    .ProjectTo<OrderExtend>(_mapper.ConfigurationProvider)
                    .Where(e => e.CreatedAt >= startDate && e.CreatedAt <= endDate);

                var notCompletedOrdersCount = await query.Where(e => e.OrderLastStatus != null && !e.OrderLastStatus.Equals(OrderStatusConst.Shipped) && !e.OrderLastStatus.Equals(OrderStatusConst.Completed) && !e.OrderLastStatus.Equals(OrderStatusConst.Cancelled) && !e.OrderLastStatus.Equals(OrderStatusConst.Returned)).CountAsync();
                var shippedOrdersCount = await query.Where(e => e.OrderLastStatus != null && e.OrderLastStatus.Equals(OrderStatusConst.Shipped)).CountAsync();
                var completedOrdersCount = await query.Where(e => e.OrderLastStatus != null && e.OrderLastStatus.Equals(OrderStatusConst.Completed)).CountAsync();
                var cancelledOrdersCount = await query.Where(e => e.OrderLastStatus != null && e.OrderLastStatus.Equals(OrderStatusConst.Cancelled)).CountAsync();
                var returnedOrdersCount = await query.Where(e => e.OrderLastStatus != null && e.OrderLastStatus.Equals(OrderStatusConst.Returned)).CountAsync();
                var ordersCount = await query.CountAsync();

                var newUsersInMonthCount = await _context.AspNetUsers.AsNoTracking()
                    .Where(u => u.CreatedAt >= startDate && u.CreatedAt <= endDate).CountAsync();

                var totalBooksSoldList = await query
                    .Select(o => new
                    {
                        o.QuantityBooksCount
                    }).ToListAsync();
                var totalBooksSold = totalBooksSoldList.Sum(e => e.QuantityBooksCount);

                var totalRevenueList = await query.Where(e => e.OrderLastStatus != null && e.OrderLastStatus.Equals(OrderStatusConst.Completed))
                    .Select(o => new
                    {
                        o.IntoMoney
                    }).ToListAsync();
                var totalRevenue = totalRevenueList.Sum(e => e.IntoMoney);

                var monthlyStatistics = new MonthlyStatisticsDTO
                {
                    Year = targetYear,
                    Month = month,
                    NotCompletedOrdersCount = notCompletedOrdersCount,
                    ShippedOrdersCount = shippedOrdersCount,
                    CompletedOrdersCount = completedOrdersCount,
                    CancelledOrdersCount = cancelledOrdersCount,
                    OrdersCount = ordersCount,
                    NewUsersInMonthCount = newUsersInMonthCount,
                    TotalBooksSold = totalBooksSold,
                    TotalRevenue = totalRevenue
                };

                statistics.Add(monthlyStatistics);
            }

            return statistics;
        }
    }
}
