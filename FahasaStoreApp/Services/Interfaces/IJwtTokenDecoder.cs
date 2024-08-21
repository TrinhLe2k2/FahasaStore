using System.Security.Claims;

namespace FahasaStoreApp.Services.Interfaces
{
    public interface IJwtTokenDecoder
    {
        ClaimsPrincipal DecodeToken(string token);
    }
}
