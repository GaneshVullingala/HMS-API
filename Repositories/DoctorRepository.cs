using EcommerceApi.Data;
using EcommerceApi.DTO;
using EcommerceApi.Interfaces;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace EcommerceApi.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;
        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<DoctorInfo> AddDoctorAsync(DoctorInfo doctorInfo, GeneralInfo generalInfo)
        {
            await _context.tblGeneralInfo.AddAsync(generalInfo);
            await _context.SaveChangesAsync();

            doctorInfo.GenId = generalInfo.Genid;
            doctorInfo.CreatedOn = DateTime.Now;

            await _context.tblDoctorInfo.AddAsync(doctorInfo);
            await _context.SaveChangesAsync();

            return doctorInfo;
        }
        public async Task<IEnumerable<DoctorInfo>> GetAllDoctorAsync()
        {
            var Entity = await _context.tblDoctorInfo.ToListAsync();
            return Entity;
        }
        public async Task<DoctorInfo?> GetDoctorByIdAsync(int id)
        {
            var Entity = await _context.tblDoctorInfo.FirstOrDefaultAsync(d=>d.DoctorId==id);
            return Entity;
        }

        public async Task<IEnumerable<DoctorInfo>> GetDoctorByNameAsync(string name)
        {

            var Entity = await _context.tblDoctorInfo.Where(d => EF.Functions.Like(d.FullName.ToLower(), $"%{name.ToLower()}%")).ToListAsync();
            return Entity;
        }
        public async Task<bool> DeleteDoctorAsync(int id)
        {
            var Doctor = await _context.tblDoctorInfo.FindAsync(id);
            if(Doctor == null)
            {
                return false;
            }

            var generalInfo = await _context.tblGeneralInfo.FindAsync(Doctor.GenId);

            _context.tblDoctorInfo.Remove(Doctor);
            
            if(generalInfo != null)
            {
                _context.tblGeneralInfo.Remove(generalInfo);
            }
            await _context.SaveChangesAsync();
           
            return true;
        }

        public async Task<DoctorInfo> UpdateDoctorAsync(int id, AddDoctorDto doctorDto)
        {
            var ExistingDoctor = await _context.tblDoctorInfo.FindAsync(id);

            if (ExistingDoctor == null)
            {
                return null;
            }
            ExistingDoctor.FullName = doctorDto.FullName;
            ExistingDoctor.Qualification = doctorDto.Qualification;
            ExistingDoctor.Experience = doctorDto.Experience;
            ExistingDoctor.Email = doctorDto.Email;
            ExistingDoctor.Pincode = doctorDto.Pincode;
            ExistingDoctor.Phone = doctorDto.Phone;
            ExistingDoctor.DocImgUrl = doctorDto.DocImgUrl;
            ExistingDoctor.Speciality = doctorDto.Speciality;
            await _context.SaveChangesAsync();
            return ExistingDoctor;
        }
    }
}
