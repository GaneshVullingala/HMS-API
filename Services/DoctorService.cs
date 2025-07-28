using EcommerceApi.DTO;
using EcommerceApi.Interfaces;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using System.Numerics;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace EcommerceApi.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repo;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }
        public async Task<DoctorInfo> AddDoctorAsync(AddDoctorDto doctorInfo)
        {
            var passwordHasher = new PasswordHasher<LoginInfo>();
            var TempPassword = doctorInfo.FullName.Substring(0, 3) + "@" + doctorInfo.Phone.Substring(doctorInfo.Phone.Length - 3);
            var LoginInfoEntity = new LoginInfo()
            {
                Role = "Doctor",
                Phone = doctorInfo.Phone,
                Username = doctorInfo.FullName.Substring(0, 3) + doctorInfo.Phone.Substring(doctorInfo.Phone.Length - 3),
                Email = doctorInfo.Email,
                Password = passwordHasher.HashPassword(null, TempPassword)
            };
            var GaneralinfoEntity = new GeneralInfo()
            {
                FullName = doctorInfo.FullName,
                Roleid = 2,
                Status = "Active",
                CreatedOn = DateTime.Now
            };
            var DoctorInfoEntity = new DoctorInfo()
            {
                FullName = doctorInfo.FullName,
                Email = doctorInfo.Email,
                Phone = doctorInfo.Phone,
                Qualification = doctorInfo.Qualification,
                Address = doctorInfo.Address,
                Speciality = doctorInfo.Speciality,
                Experience = doctorInfo.Experience,
                PhotoImgUrl = doctorInfo.PhotoImgUrl,
                DocImgUrl = doctorInfo.DocImgUrl,
                Pincode = doctorInfo.Pincode,

            };
            var ContactInfoEntity = new CommunicationInfo()
            {
                Phone = doctorInfo.Phone,
                Email = doctorInfo.Email,
            };
            await _repo.AddDoctorAsync(DoctorInfoEntity, GaneralinfoEntity, LoginInfoEntity, ContactInfoEntity);
            return DoctorInfoEntity;

        }
        public async Task<IEnumerable<DoctorInfo>> GetAllDoctorAsync()
        {
            return await _repo.GetAllDoctorAsync();
        }
        public async Task<DoctorInfo?> GetDoctorByIdAsync(int id)
        {
            return await _repo.GetDoctorByIdAsync(id);
        }

        public async Task<IEnumerable<DoctorInfo>> GetDoctorByNameAsync(string name)
        {
            return await _repo.GetDoctorByNameAsync(name);
        }
        public async Task<bool> DeleteDoctorAsync(int id)
        {
            return await _repo.DeleteDoctorAsync(id);
        }

        public async Task<DoctorInfo> UpdateDoctorAsync(int id, AddDoctorDto doctordto)
        {
            return await _repo.UpdateDoctorAsync(id, doctordto);
        }

        public async Task<ConsultationInfo> UpdateConsultationInfoAsync(ConsultationDto consultationdto)
        {
            if (consultationdto == null)
            {
                throw new ArgumentNullException(nameof(consultationdto), "Consultation information cannot be null.");
            }
            var consultation = await _repo.GetConsultationByIdAsync(consultationdto.ConsultId);
            if (consultation == null)
            {
                throw new KeyNotFoundException($"Consultation with ID {consultationdto.ConsultId} not found.");
            }
            var consultEntity = _mapper.Map(consultationdto, consultation);
            await _repo.UpdateConsultationInfoAsync(consultEntity);
            return consultEntity;
        }

        public async Task<bool?> AddPrescriptionAsync(PrescriptionDto prescriptiondto)
        {
            var isCounsult = await _repo.GetConsultationByIdAsync(prescriptiondto.ConsultId);
            if (isCounsult == null)
            {
                throw new KeyNotFoundException($"Consultation with ID {prescriptiondto.ConsultId} not found.");
            }
            var prescriptionEntity = _mapper.Map<PrescriptionInfo>(prescriptiondto);
            await _repo.AddPrescriptionAsync(prescriptionEntity);
            return true;
        }
    }
}
