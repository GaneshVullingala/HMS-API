using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IGeneralRepostiory
    {
        Task<PatientInfo?> GetPatientByIdAsync(int patientId);
    }
}
