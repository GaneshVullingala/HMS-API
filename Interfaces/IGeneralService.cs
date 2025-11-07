using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IGeneralService
    {

        Task<ConsultationView> GetConsultationInfoByIdAsync(int ConsultId);
    }
}
