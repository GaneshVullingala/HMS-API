using EcommerceApi.Data;
using EcommerceApi.DTO;
using EcommerceApi.Interfaces;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<DoctorInfo> AddDoctorAsync(DoctorInfo doctorInfo, GeneralInfo generalInfo, LoginInfo loginInfo, CommunicationInfo communicationinfo)
        {

            using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {

                // Step 1: Insert General Info
                await _context.tblGeneralInfo.AddAsync(generalInfo);
                await _context.SaveChangesAsync();

                // Step 2: Link IDs and add Doctor Info
                doctorInfo.GenId = generalInfo.Genid;
                doctorInfo.CreatedOn = DateTime.Now;

                await _context.tblDoctorInfo.AddAsync(doctorInfo);
                await _context.SaveChangesAsync();

                // Step 3: Add Login Info and Communication Info
                loginInfo.Genid = generalInfo.Genid;
                loginInfo.UserId = doctorInfo.DoctorId;
                communicationinfo.GenId = generalInfo.Genid;

                await _context.tblLoginInfo.AddAsync(loginInfo);
                await _context.tblCommunicationInfo.AddAsync(communicationinfo);

                await _context.SaveChangesAsync();
                // Step 4: Commit transaction if all succeed
                await transaction.CommitAsync();

                return doctorInfo;

                }
                catch (Exception)
                {
                    // Step 5: Rollback transaction if any step fails
                    await transaction.RollbackAsync();
                    throw; // Re-throw the exception after rollback
                }

            }
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
            if(generalInfo != null)
            {
                var loginingo = await _context.tblLoginInfo.Where(s => s.Genid == generalInfo.Genid).FirstOrDefaultAsync();
                var communicationinfo = await _context.tblCommunicationInfo.Where(s => s.GenId == generalInfo.Genid).FirstOrDefaultAsync();
                _context.tblDoctorInfo.Remove(Doctor);
                _context.tblCommunicationInfo.Remove(communicationinfo);
                _context.tblLoginInfo.Remove(loginingo);
            }
                _context.tblGeneralInfo.Remove(generalInfo);
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
            //ExistingDoctor.DocImgUrl = doctorDto.DocImgUrl;
            //ExistingDoctor.Speciality = doctorDto.Speciality;

            // Handle file uploads if present
                if (doctorDto.PhotoImg != null)
                {
                    var photoFolder = Path.Combine("Uploads", "Photos");
                    Directory.CreateDirectory(photoFolder);

                    var photoFileName = Guid.NewGuid() + Path.GetExtension(doctorDto.PhotoImg.FileName);
                    var photoPath = Path.Combine(photoFolder, photoFileName);

                    using (var stream = new FileStream(photoPath, FileMode.Create))
                    {
                        await doctorDto.PhotoImg.CopyToAsync(stream);
                    }

                    // ✅ Store web-accessible path
                    ExistingDoctor.PhotoImgUrl = "/Uploads/Photos/" + photoFileName;
                 }
                

                if (doctorDto.DocImg != null)
                {
                    var docFolder = Path.Combine("Uploads", "Photos");
                    Directory.CreateDirectory(docFolder);

                    var docFileName = Guid.NewGuid() + Path.GetExtension(doctorDto.DocImg.FileName);
                    var docPath = Path.Combine(docFolder, docFileName);

                    using (var stream = new FileStream(docPath, FileMode.Create))
                    {
                        await doctorDto.DocImg.CopyToAsync(stream);
                    }

                    // ✅ Store web-accessible path
                    ExistingDoctor.DocImgUrl = "/Uploads/Photos/" + docFileName;
                }
               

                await _context.SaveChangesAsync();
            return ExistingDoctor;
        }
        public async Task<ConsultationInfo?> GetConsultationByIdAsync(int id)
        {
            return await _context.tblConsultationInfo.FindAsync(id);
        }
        public async Task<ConsultationInfo> UpdateConsultationInfoAsync(ConsultationInfo consultationInfo)
        {
            await _context.SaveChangesAsync();
            return consultationInfo;
        }

        public async Task<bool> AddPrescriptionAsync(PrescriptionInfo prescription)
        {
            await _context.tblprescriptionInfo.AddAsync(prescription);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
