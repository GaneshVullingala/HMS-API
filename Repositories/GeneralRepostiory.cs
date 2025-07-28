using EcommerceApi.Data;
using EcommerceApi.Interfaces;

using EcommerceApi.Models;

namespace EcommerceApi.Repositories
{
    public class GeneralRepostiory : IGeneralRepostiory
    {
        private readonly AppDbContext _context;
        public GeneralRepostiory(AppDbContext context)
        {
            _context = context;
        }
        public async Task<PatientInfo?> GetPatientByIdAsync(int patientId)
        {
            return await _context.tblPatientInfo.FindAsync(patientId);
        }
    }
}
