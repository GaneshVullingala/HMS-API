using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface ILoginRepository
    {
        Task<LoginInfo> GetLoginAsync(string username, string password);

    }
}
