using EcommerceApi.DTO;
using EcommerceApi.Interfaces;

namespace EcommerceApi.Services
{
    public class GeneralService : IGeneralService
    {
        private readonly IGeneralRepostiory _generalRepostiory;
        public GeneralService(IGeneralRepostiory generalRepostiory)
        {
            _generalRepostiory = generalRepostiory;
        }   

        public async Task<ConsultationViewDto> GetConsultationInfoByIdAsync(int ConsultId)
        {
            var consultation = await _generalRepostiory.GetConsultationInfoByIdAsync(ConsultId);
            if (consultation == null)
            {
                throw new Exception("Consultation not found");
            }
            return consultation;
        }

    }
}
