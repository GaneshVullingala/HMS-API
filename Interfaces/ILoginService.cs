using EcommerceApi.DTO;

namespace EcommerceApi.Interfaces
{
    public interface ILoginService
    {
        Task<string> AuthenticateAsync(string username, string password);
        //jwt
        Task<LoginResponce> GetLoginResponceAsync(string username, string password);
    }
}
