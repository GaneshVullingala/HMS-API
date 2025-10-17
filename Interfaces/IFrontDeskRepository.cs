using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IFrontDeskRepository
    {
        Task<FrontDeskInfo> AddFrontDesk(FrontDeskInfo frontDeskInfo, GeneralInfo generalInfo, LoginInfo loginInfo, CommunicationInfo communicationInfo);
        Task<PatientInfo> AddPatient(PatientInfo patientInfo, GeneralInfo generalInfo, LoginInfo loginInfo, CommunicationInfo communicationInfo, ConsultationInfo consultationInfo);
    
        Task<int> AddPatientVitals(PatientVitalsInfo patientVitalsInfo);

        Task<IEnumerable<FrontDeskInfo>> GetAllFrontDeskAsync();

        Task<PatientVitalsInfo> GetPatientVitalsById(int Id);

        Task<ConsultationInfo> AddConsultation(ConsultationInfo consultation);  

        Task<PatientInfo> GetPatientByIdAsync(int patientId);
    }
}
