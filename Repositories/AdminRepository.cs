using EcommerceApi.Data;
using EcommerceApi.Interfaces;
using EcommerceApi.DTO;
using Microsoft.EntityFrameworkCore;
using EcommerceApi.Models;

namespace EcommerceApi.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;
        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AdminCountDto> GetAllCountAsync()
        {
            var TotalConsultCount = await _context.tblConsultationInfo.CountAsync();
            var TotalDoctorCount = await _context.tblDoctorInfo.CountAsync();
            var TotalPatientCount = await _context.tblPatientInfo.CountAsync(); 
            var TotalFrontDeskCount = await _context.tblFrontDeskInfo.CountAsync();
            var PendingConsultionCount = await _context.tblConsultationInfo.Where(c => c.CurrentStatus != "Consultation Completed").CountAsync();
            var CompletedConsultionCount = await _context.tblConsultationInfo.Where(c => c.CurrentStatus == "Consultation Completed").CountAsync();
            var TotalFee = await _context.tblConsultationInfo.SumAsync(c => c.Fee);
            var TotalProfit = TotalFee *50 /100;
            var adminCountDto = new AdminCountDto
            {
                AllConsultations = TotalConsultCount,
                PendingConsultations = PendingConsultionCount,
                CompletedConsultations = CompletedConsultionCount,
                TotalFeeCollected = Convert.ToInt32(TotalFee),
                TotalPatientRegistered = TotalPatientCount,
                TotalDoctors = TotalDoctorCount,
                TotalFrontDesks = TotalFrontDeskCount,
                TotalProfit = Convert.ToInt32(TotalProfit)
            };

            return adminCountDto;
        }
        public async Task<IEnumerable<ConsultationView?>> GetAllConsultationsByStatusAsync(string status)
        {
            if (status != null)
            {
                if (status == "All")
                {
                    var result = await _context.Consultation_V.ToListAsync();
                    return result;
                }
                else if (status == "pending")
                {
                    var result = await _context.Consultation_V.Where(c => c.CurrentStatus == "Registered").ToListAsync();
                    return result;
                }
                else if (status == "Consultation Completed")
                {
                    var result = await _context.Consultation_V.Where(c => c.CurrentStatus == "Consultation Completed").ToListAsync();
                    return result;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }
    }
}
