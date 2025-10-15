using AutoMapper;
using EcommerceApi.DTO;
using EcommerceApi.Interfaces;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Identity;

namespace EcommerceApi.Services
{
    public class FrontDeskService : IFrontDeskService
    {
        private readonly IFrontDeskRepository _frontDeskRepository;
        private readonly IGeneralRepostiory _generalRepository;
        private readonly IMapper _mapper;
        public FrontDeskService(IFrontDeskRepository frontDeskRepository, IMapper mapper, IGeneralRepostiory generalRepostiory)
        {
            _frontDeskRepository = frontDeskRepository;
            _mapper = mapper;
            _generalRepository = generalRepostiory;
        }

        public async Task<AddFrontDeskDTO> AddFrontDeskAsync(AddFrontDeskDTO frontDeskDTO)
        {
            var passwordHasher = new PasswordHasher<LoginInfo>();
            var TempPassword = frontDeskDTO.FullName.Substring(0, 3) + "@" + frontDeskDTO.Phone.Substring(frontDeskDTO.Phone.Length - 3);
            var LoginInfoEntity = new LoginInfo()
            {
                Role = "FrontDesk",
                Phone = frontDeskDTO.Phone,
                Username = frontDeskDTO.FullName.Substring(0, 3) + frontDeskDTO.Phone.Substring(frontDeskDTO.Phone.Length - 3),
                Email = frontDeskDTO.Email,
                Password = passwordHasher.HashPassword(null, TempPassword)
            };
            var GeneralinfoEntity = new GeneralInfo()
            {
                FullName = frontDeskDTO.FullName,
                Roleid = 3,
                Status = "Active",
                CreatedOn = DateTime.Now,
            };
            var FronDeskEntity = new FrontDeskInfo()
            {
                FullName = frontDeskDTO.FullName,
                Email = frontDeskDTO.Email,
                Phone = frontDeskDTO.Phone,
                Qualification = frontDeskDTO.Qualification,
                Address = frontDeskDTO.Address,
                Speciality = frontDeskDTO.Speciality,
                Experience = frontDeskDTO.Experience,
                PhotoImgUrl = frontDeskDTO.PhotoImgUrl,
                DocImgUrl = frontDeskDTO.DocImgUrl,
                Pincode = frontDeskDTO.Pincode
            };
            if(frontDeskDTO.DocImg != null)
            {
                var docFileName = Guid.NewGuid() + Path.GetExtension(frontDeskDTO.DocImg.FileName);
                var docPath = Path.Combine("Uploads/Photos", docFileName);
                using (var stream = new FileStream(docPath, FileMode.Create))
                {
                    await frontDeskDTO.DocImg.CopyToAsync(stream);
                }
                FronDeskEntity.DocImgUrl = docPath;
            }

            if (frontDeskDTO.PhotoImg != null)
            {
                var photoFileName = Guid.NewGuid() + Path.GetExtension(frontDeskDTO.PhotoImg.FileName);
                var photoPath = Path.Combine("Uploads/Photos", photoFileName);
                using (var stream = new FileStream(photoPath, FileMode.Create))
                {
                    await frontDeskDTO.PhotoImg.CopyToAsync(stream);
                }
                FronDeskEntity.PhotoImgUrl = photoPath;
            }


            var CommunicationInfoEntity = new CommunicationInfo()
            {
                Phone = frontDeskDTO.Phone,
                Email = frontDeskDTO.Email,
            };
            await _frontDeskRepository.AddFrontDesk(FronDeskEntity, GeneralinfoEntity, LoginInfoEntity, CommunicationInfoEntity);
            return frontDeskDTO;
        }


        public async Task<AddPatientDto> AddPatientAsync(AddPatientDto patientDTO)
        {
            var passwordHasher = new PasswordHasher<LoginInfo>();
            var TempPassword = patientDTO.FullName.Substring(0, 3) + "@" + patientDTO.Phone.Substring(patientDTO.Phone.Length - 3);
            var LoginInfoEntity = new LoginInfo()
            {
                Role = "Patient",
                Phone = patientDTO.Phone,
                Username = patientDTO.FullName.Substring(0, 3) + patientDTO.Phone.Substring(patientDTO.Phone.Length - 3),
                Email = patientDTO.Email,
                Password = passwordHasher.HashPassword(null, TempPassword)
            };

            var GeneralinfoEntity = new GeneralInfo()
            {
                FullName = patientDTO.FullName,
                Roleid = 4,
                Status = "Active",
                CreatedOn = DateTime.Now,
            };
            var CommunicationInfoEntity = new CommunicationInfo()
            {
                Phone = patientDTO.Phone,
                Email = patientDTO.Email,
            };
            var ConsultinfoEntity = new ConsultationInfo()
            {
                FrontDeskId = patientDTO.FrontDeskId,
                CurrentStatus = "Waiting for Consultation",
                DoctorId = patientDTO.DoctorId,
                CreatedOn = DateTime.Now,
                Diognosis = "Pending",
                Problem = "Pending",
                Advice = "Pending",
                RevisitDate = DateTime.Now.AddDays(7) // Default revisit date set to 7 days later

            };


            var patientifoEntity = _mapper.Map<PatientInfo>(patientDTO);

            var savedPatient = await _frontDeskRepository.AddPatient(patientifoEntity, GeneralinfoEntity, LoginInfoEntity, CommunicationInfoEntity, ConsultinfoEntity);
            return _mapper.Map<AddPatientDto>(savedPatient);
        }

        public async Task<bool> AddPatinetVitals(PatientVitalsDto patientVitalsdto)
        {
            if (patientVitalsdto == null)
            {
                throw new ArgumentNullException(nameof(patientVitalsdto), "Patient vitals data cannot be null");
            }
            var ispatient = await _generalRepository.GetPatientByIdAsync(patientVitalsdto.PatientId);
            if (ispatient == null)
            {
                throw new ArgumentException($"Patient with ID {patientVitalsdto.PatientId} does not exist.");
            }
            var patientVitalsEntity = _mapper.Map<PatientVitalsInfo>(patientVitalsdto);
            await _frontDeskRepository.AddPatientVitals(patientVitalsEntity);
            return true;
        }

        public async Task<IEnumerable<FrontDeskInfo>> GetAllFrontDeskInfoAsync()
        {
            return await _frontDeskRepository.GetAllFrontDeskAsync();
        }

        public async Task<PatientVitalsInfo> GetPatientVitalsById(int Id)
        {
            return await _frontDeskRepository.GetPatientVitalsById(Id);
        }

        public async Task<ConsultationDto> AddConsultationAsync(ConsultationDto consultationDto)
        {
            var consultationetity = _mapper.Map<ConsultationInfo>(consultationDto);
            await _frontDeskRepository.AddConsultation(consultationetity);
            return consultationDto;
        }
    }
}
