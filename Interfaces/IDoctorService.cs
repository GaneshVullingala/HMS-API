using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IDoctorService
    {
        Task<DoctorInfo> AddDoctorAsync(AddDoctorDto doctorInfo);
        Task<IEnumerable<DoctorInfo>> GetAllDoctorAsync();
        Task<DoctorInfo?> GetDoctorByIdAsync(int id);

        Task<IEnumerable<DoctorInfo>> GetDoctorByNameAsync(string name);
        Task<bool> DeleteDoctorAsync(int id);

        Task<DoctorInfo> UpdateDoctorAsync(int id,AddDoctorDto doctordto);
    }
}
