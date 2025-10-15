using EcommerceApi.Data;
using EcommerceApi.DTO;
using EcommerceApi.Interfaces;
using EcommerceApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
namespace EcommerceApi.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientInfo>> GetAllPatientsAsync()
        {
            return await _repo.GetAllPatientsAsync();
        }

        public async Task<PatientInfo> AddPatientAsync(AddPatientDto addPatientDto)
        {
            var passwordHasher = new PasswordHasher<LoginInfo>();
            var TempPassword = addPatientDto.FullName.Substring(0, 3) + "@" + addPatientDto.Phone.Substring(addPatientDto.Phone.Length - 3);
            var LoginInfoEntity = new LoginInfo()
            {
                Role = "Patient",
                Phone = addPatientDto.Phone,
                Username = addPatientDto.FullName.Substring(0, 3) + addPatientDto.Phone.Substring(addPatientDto.Phone.Length - 3),
                Email = addPatientDto.Email,
                Password = passwordHasher.HashPassword(null, TempPassword)
            };
            var GaneralinfoEntity = new GeneralInfo()
            {
                FullName = addPatientDto.FullName,
                Roleid = 3,
                Status = "Active",
                CreatedOn = DateTime.Now
            };
            var CommunicationInfoEntity = new CommunicationInfo()
            {
                Email = addPatientDto.Email,
                Phone = addPatientDto.Phone,
            };
            var PatientInfoEntity = new PatientInfo()
            {
                FrontdeskId = addPatientDto.FrontDeskId,
                FullName = addPatientDto.FullName,
                Email = addPatientDto.Email,
                Phone = addPatientDto.Phone,
                PresentProblem = addPatientDto.PresentProblem,
                PreviousHistory = addPatientDto.PreviousHistory,
                Address = addPatientDto.Address,
                Pincode = addPatientDto.Pincode,
                //Fee = addPatientDto.Fee,
            };
            return await _repo.AddPatientAsync(PatientInfoEntity, GaneralinfoEntity,LoginInfoEntity, CommunicationInfoEntity);
        }
    } 
}
