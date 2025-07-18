using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IDoctorRepository
    {
        Task<DoctorInfo> AddDoctorAsync(DoctorInfo doctorInfo, GeneralInfo generalInfo);
        Task<IEnumerable<DoctorInfo>> GetAllDoctorAsync();
        Task<DoctorInfo?> GetDoctorByIdAsync(int id);

        Task<IEnumerable<DoctorInfo>> GetDoctorByNameAsync(string name);
        Task<bool> DeleteDoctorAsync(int id);

        Task<DoctorInfo> UpdateDoctorAsync(int id, AddDoctorDto doctorDto);
    }
}
