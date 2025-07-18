using EcommerceApi.DTO;
using EcommerceApi.Interfaces;
using EcommerceApi.Models;
using EcommerceApi.Data;

namespace EcommerceApi.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repo;
        public RoleService(IRoleRepository roleRepository) 
        {
            _repo = roleRepository;
        }

        public async Task<IEnumerable<RoleInfo>> GetAllRolesAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<RoleInfo> GetRolebyIdAsync(int id)
        {
            return await _repo.GetbyIdAsync(id);
        }

        public async Task<RoleInfo> AddAsync(RoleDto roleDto) 
        {
            var tblrole = new RoleInfo
            {
                RoleName = roleDto.RoleName,
                Status = roleDto.Status
            };
            await _repo.AddAsync(tblrole);
            await _repo.SaveAsync();

            return tblrole;
        }

        public async Task<RoleInfo> UpdateAsync(int id, RoleDto roleDto)
        {
            var existing = await _repo.GetbyIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Role with ID {id} not found.");

            else
            {
                existing.RoleName = roleDto.RoleName;
                existing.Status = roleDto.Status;
                await _repo.UpdateAync(existing);
                await _repo.SaveAsync();
                return existing;
            }
              
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var role = await _repo.GetbyIdAsync(id);
            if (role == null) return false;

            await _repo.DeleteAsync(id);
            return true;
        }
    }
}
