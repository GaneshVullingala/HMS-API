using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IGeneralRepostiory
    {

        Task<ConsultationView?> GetConsultationInfoByIdAsync(int ConsultId);
    }
}
