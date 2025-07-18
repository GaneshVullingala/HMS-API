using EcommerceApi.Data;
using EcommerceApi.DTO;
using EcommerceApi.Interfaces;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace EcommerceApi.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<RoleInfo>> GetAllAsync()
        {
            return await _context.tblRoleInfo.ToListAsync();
        }

        public async Task<RoleInfo> GetbyIdAsync(int id)
        {
            var existingEntity = await _context.tblRoleInfo.FindAsync(id);
            if (existingEntity != null) 
            {
                return await _context.tblRoleInfo.FindAsync(id);
            }
            else
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }
        }

        public async Task AddAsync(RoleInfo roleinfo)
        {
            await _context.tblRoleInfo.AddAsync(roleinfo);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.tblRoleInfo.FindAsync(id);
            if (entity != null)
            {
                _context.tblRoleInfo.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAync(RoleInfo roleInfo) 
        {
            var existingEntity = await _context.tblRoleInfo.FindAsync(roleInfo.RoledId);
            if (existingEntity == null) 
            {
                throw new KeyNotFoundException($"Entity with id {roleInfo.RoledId} not found.");
            }
            _context.Entry(existingEntity).CurrentValues.SetValues(roleInfo);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
