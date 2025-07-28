using EcommerceApi.DTO;

namespace EcommerceApi.Interfaces
{
    public interface IFrontDeskService
    {
        Task<AddFrontDeskDTO> AddFrontDeskAsync(AddFrontDeskDTO frontDeskDTO);

        Task<AddPatientDto> AddPatientAsync(AddPatientDto patientDTO);

        Task<bool> AddPatinetVitals(PatientVitalsDto patientVitalsdto);
    }
}
