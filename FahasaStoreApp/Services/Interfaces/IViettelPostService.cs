using FahasaStoreApp.Models;

namespace FahasaStoreApp.Services.Interfaces
{
    public interface IViettelPostService
    {
        Task<IEnumerable<Province>> GetListProvince();
        Task<IEnumerable<District>> GetListDistrictByProvinceId(int provinceId);
        Task<IEnumerable<Ward>> GetListWardByDistrictId(int districtId);
    }
}
