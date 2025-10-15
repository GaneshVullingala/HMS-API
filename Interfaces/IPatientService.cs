using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientInfo>> GetAllPatientsAsync();
        //Task<PatientInfo?> GetPatientByIdAsync(int id);
        Task<PatientInfo> AddPatientAsync(AddPatientDto addPatientDto);
        //Task<PatientInfo> UpdatePatientAsync(int id, PatientInfo patientInfo);
        //Task<bool> DeletePatientAsync(int id);
        //Task<bool> AddPatientVitalsAsync(PatientVitalsInfo patientVitalsInfo);
    }
}
