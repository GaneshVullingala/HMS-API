using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<PatientInfo>> GetAllPatientsAsync();
        //Task<PatientInfo?> GetPatientByIdAsync(int id);
        Task<PatientInfo> AddPatientAsync(PatientInfo patientInfo, GeneralInfo generalInfo, LoginInfo loginInfo, CommunicationInfo communicationinfo);
        //Task<PatientInfo> UpdatePatientAsync(int id, PatientInfo patientInfo);
        //Task<bool> DeletePatientAsync(int id);
        //Task<bool> AddPatientVitalsAsync(PatientVitalsInfo patientVitalsInfo);
    }
}
