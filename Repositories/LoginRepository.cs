using EcommerceApi.Data;
using EcommerceApi.DTO;
using Microsoft.EntityFrameworkCore;
using EcommerceApi.Interfaces;
using EcommerceApi.Models;

namespace EcommerceApi.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;
        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<LoginInfo> GetLoginAsync(string username, string password)
        {
            return await _context.tblLoginInfo.FirstOrDefaultAsync(u => (u.Username == username || u.Email == username || u.Phone == username) && u.Password == password);
        }
    }
}
