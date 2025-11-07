using EcommerceApi.Interfaces;
using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminrepo;
        public AdminService(IAdminRepository adminrepo)
        {
            _adminrepo = adminrepo;
        }

        public async Task<AdminCountDto> GetAllCountAsync()
        {
            return await _adminrepo.GetAllCountAsync();
        }

        public async Task<IEnumerable<ConsultationView?>> GetAllConsultationsByStatusAsync(string status)
        {
            return await _adminrepo.GetAllConsultationsByStatusAsync(status);
        }   
    }
}
