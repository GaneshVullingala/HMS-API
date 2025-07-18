using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleInfo>> GetAllAsync();
        Task<RoleInfo> GetbyIdAsync(int id);
        Task AddAsync(RoleInfo roleInfo);

        Task UpdateAync(RoleInfo roleInfo); 
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
