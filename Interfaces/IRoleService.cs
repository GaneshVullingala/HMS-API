using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleInfo>> GetAllRolesAsync();
        Task<RoleInfo> GetRolebyIdAsync(int id);
        Task<RoleInfo> AddAsync(RoleDto roleDto);

        Task<RoleInfo> UpdateAsync(int id, RoleDto roleDto);
        Task<bool> DeleteAsync(int id);
    }
}
