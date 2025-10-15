using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IDoctorRepository
    {
        Task<DoctorInfo> AddDoctorAsync(DoctorInfo doctorInfo, GeneralInfo generalInfo, LoginInfo loginInfo, CommunicationInfo communicationinfo);
        Task<IEnumerable<DoctorInfo>> GetAllDoctorAsync();
        Task<DoctorInfo?> GetDoctorByIdAsync(int id);

        Task<IEnumerable<DoctorInfo>> GetDoctorByNameAsync(string name);
        Task<bool> DeleteDoctorAsync(int id);

        Task<DoctorInfo> UpdateDoctorAsync(int id, AddDoctorDto doctorDto);

        Task<ConsultationInfo> UpdateConsultationInfoAsync(ConsultationInfo consultationInfo);

        Task<ConsultationInfo?> GetConsultationByIdAsync(int id);

        Task<bool> AddPrescriptionAsync(PrescriptionInfo prescription);

        //Task<IEnumerable<ConsultationInfo>> GetAllConsultationsAsync();

        Task<IEnumerable<ConsultationInfo>> GetConsultationsByDoctorId(int Id);

    }
}
