using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IGeneralService
    {

        Task<ConsultationViewDto> GetConsultationInfoByIdAsync(int ConsultId);
    }
}
