using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IGeneralRepostiory
    {

        Task<ConsultationViewDto?> GetConsultationInfoByIdAsync(int ConsultId);
    }
}
