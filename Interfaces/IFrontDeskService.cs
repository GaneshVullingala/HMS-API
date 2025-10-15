using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IFrontDeskService
    {
        Task<AddFrontDeskDTO> AddFrontDeskAsync(AddFrontDeskDTO frontDeskDTO);

        Task<AddPatientDto> AddPatientAsync(AddPatientDto patientDTO);

        Task<bool> AddPatinetVitals(PatientVitalsDto patientVitalsdto);

        Task<IEnumerable<FrontDeskInfo>> GetAllFrontDeskInfoAsync();

        Task<PatientVitalsInfo> GetPatientVitalsById(int Id);

        Task<ConsultationDto> AddConsultationAsync(ConsultationDto consultationDTO); 
    }
}
