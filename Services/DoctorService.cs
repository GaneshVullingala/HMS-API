using EcommerceApi.DTO;
using EcommerceApi.Interfaces;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using System.Numerics;

namespace EcommerceApi.Services 
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repo;
        public DoctorService(IDoctorRepository repository)
        {
            _repo = repository;
        }
        public async Task<DoctorInfo> AddDoctorAsync(AddDoctorDto doctorInfo)
        {
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
            await _repo.AddDoctorAsync(DoctorInfoEntity, GaneralinfoEntity);
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
    }
}
