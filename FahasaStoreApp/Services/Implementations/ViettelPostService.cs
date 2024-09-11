using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models;
using FahasaStoreApp.Services.Interfaces;

namespace FahasaStoreApp.Services.Implementations
{
    public class ViettelPostService : IViettelPostService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMethodsHelper _methodsHelper;

        public ViettelPostService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper)
        {
            _httpClientFactory = httpClientFactory;
            _methodsHelper = methodsHelper;
        }

        public async Task<IEnumerable<Province>> GetListProvince()
        {
            var endpoint = "https://partner.viettelpost.vn/v2/categories/listProvince";
            var result = await _methodsHelper.RequestHttpGet<ViettelPost<Province>>(_httpClientFactory, endpoint, endpoint);
            return result.Data;
        }

        public async Task<IEnumerable<District>> GetListDistrictByProvinceId(int provinceId)
        {
            var endpoint = "https://partner.viettelpost.vn/v2/categories/listDistrict?provinceId=" + provinceId;
            var result = await _methodsHelper.RequestHttpGet<ViettelPost<District>>(_httpClientFactory, endpoint, endpoint);
            return result.Data;
        }

        public async Task<IEnumerable<Ward>> GetListWardByDistrictId(int districtId)
        {
            var endpoint = "https://partner.viettelpost.vn/v2/categories/listWards?districtId=" + districtId;
            var result = await _methodsHelper.RequestHttpGet<ViettelPost<Ward>>(_httpClientFactory, endpoint, endpoint);
            return result.Data;
        }
    }
}
