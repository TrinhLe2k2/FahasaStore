using FahasaStore.Models;
using FahasaStoreApp.Areas.User.Models;
using FahasaStoreApp.Base;
using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models;

namespace FahasaStoreApp.Areas.User.Services
{
    public interface IOrderUserService : IBaseService<CustomerOrder, OrderDetail, OrderExtend, OrderBase>
    {
        Task<ApiResponse<OrderDetail>> CancelOrderAsync(int orderId);
    }
    public class OrderUserService : BaseService<CustomerOrder, OrderDetail, OrderExtend, OrderBase>, IOrderUserService
    {
        public OrderUserService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper) : base(httpClientFactory, methodsHelper)
        {
        }

        public async Task<ApiResponse<OrderDetail>> CancelOrderAsync(int orderId)
        {
            string endpoint = "/" + _methodsHelper.PluralizeWord<CustomerOrder>() + "/Cancel?orderId=" + orderId;
            var result = await _methodsHelper.RequestHttpGet<ApiResponse<OrderDetail>>(_httpClientFactory, endpoint);
            return result;
        }
    }
}
