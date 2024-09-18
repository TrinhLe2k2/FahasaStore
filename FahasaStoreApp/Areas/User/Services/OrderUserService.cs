using FahasaStore.Models;
using FahasaStoreApp.Areas.Base;
using FahasaStoreApp.Areas.User.Models;
using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models;
using FahasaStoreApp.Services;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace FahasaStoreApp.Areas.User.Services
{
    public interface IOrderUserService : IBaseService<CustomerOrders, OrderDetail, OrderExtend, OrderBase>
    {
        Task<ApiResponse<OrderDetail>> CancelOrderAsync(int orderId);
    }
    public class OrderUserService : BaseService<CustomerOrders, OrderDetail, OrderExtend, OrderBase>, IOrderUserService
    {
        public OrderUserService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }

        public async Task<ApiResponse<OrderDetail>> CancelOrderAsync(int orderId)
        {
            string endpoint = "/" + nameof(CustomerOrders) + "/Cancel?orderId=" + orderId;
            var result = await _methodsHelper.RequestHttpGet<ApiResponse<OrderDetail>>(_httpClientFactory, endpoint);
            return result;
        }
    }
}
