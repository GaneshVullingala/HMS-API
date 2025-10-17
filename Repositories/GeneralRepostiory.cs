using EcommerceApi.Data;
using EcommerceApi.DTO;
using EcommerceApi.Interfaces;

using EcommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Repositories
{
    public class GeneralRepostiory : IGeneralRepostiory
    {
        private readonly AppDbContext _context;
        public GeneralRepostiory(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ConsultationViewDto?> GetConsultationInfoByIdAsync(int consultId)
        {
            return await _context.Consultation_V.Where(c => c.ConsultId == consultId).FirstOrDefaultAsync();
        }
    }
}
