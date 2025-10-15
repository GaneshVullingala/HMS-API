using EcommerceApi.Data;
using EcommerceApi.DTO;
using Microsoft.EntityFrameworkCore;
using EcommerceApi.Interfaces;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Identity;

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
            var user = await _context.tblLoginInfo.FirstOrDefaultAsync(u => u.Username == username || u.Email == username || u.Phone == username);
            if (user == null)
                return null;

            var hasher = new PasswordHasher<LoginInfo>();
            var result = hasher.VerifyHashedPassword(user, user.Password, password);
            if (result == PasswordVerificationResult.Success)
                return user;

            return null;
        }

        public async Task<LoginResponce> GetLoginResponceAsync(string username, string password)
        {
            var user = await _context.tblLoginInfo.Include(u => u.GeneralInfo)
                .FirstOrDefaultAsync(u => u.Username == username || u.Email == username || u.Phone == username);
            if (user == null)
                return null;
            var hasher = new PasswordHasher<LoginInfo>();
            var result = hasher.VerifyHashedPassword(user, user.Password, password);
            if (result == PasswordVerificationResult.Success)
            {
                // generate fake sessionId (Guid)
                var sessionId = Guid.NewGuid().ToString();
                var Userresponce = new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Role = user.Role
                };

                var response = new LoginResponce
                {
                    Success = true,
                    Message = "Login successful",
                    User = Userresponce,
                    SessionId = sessionId
                };
                return response;

            }
            return null;
        }
    }
}
