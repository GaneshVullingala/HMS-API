using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IAdminService
    {
        Task<AdminCountDto> GetAllCountAsync();
        Task<IEnumerable<ConsultationView?>> GetAllConsultationsByStatusAsync(string Status);
    }
}
