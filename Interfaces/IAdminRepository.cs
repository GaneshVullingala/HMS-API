using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IAdminRepository
    {
        Task<AdminCountDto> GetAllCountAsync();
        Task<IEnumerable<ConsultationView?>> GetAllConsultationsByStatusAsync(string status);
    }
}
