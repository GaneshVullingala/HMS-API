using EcommerceApi.Data;
using EcommerceApi.Interfaces;
using EcommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;
        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PatientInfo>> GetAllPatientsAsync()
        {
            return await _context.tblPatientInfo.ToListAsync();
        }
        public async Task<PatientInfo> AddPatientAsync(PatientInfo patientInfo, GeneralInfo generalInfo, LoginInfo loginInfo, CommunicationInfo communicationInfo)
        {
            await _context.tblGeneralInfo.AddAsync(generalInfo);
            await _context.SaveChangesAsync();

            patientInfo.Genid = generalInfo.Genid;
            patientInfo.CreatedOn = DateTime.Now;
            loginInfo.Genid = generalInfo.Genid;
            communicationInfo.GenId = generalInfo.Genid;


            await _context.tblPatientInfo.AddAsync(patientInfo);
            await _context.SaveChangesAsync();

            loginInfo.UserId = patientInfo.PatientId;
            await _context.tblLoginInfo.AddAsync(loginInfo);
            await _context.SaveChangesAsync();

            await _context.tblCommunicationInfo.AddAsync(communicationInfo);
            await _context.SaveChangesAsync();

            return patientInfo;
        }
    }
}
