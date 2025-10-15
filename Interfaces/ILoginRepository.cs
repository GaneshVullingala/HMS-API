using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface ILoginRepository
    {
        Task<LoginInfo> GetLoginAsync(string username, string password);
        //jwt

        Task<LoginResponce> GetLoginResponceAsync(string username, string password);

    }
}
