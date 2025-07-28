using AutoMapper;
using EcommerceApi.DTO;
using EcommerceApi.Models;
using System.Diagnostics;
namespace EcommerceApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddPatientDto, PatientInfo>();
            CreateMap<PatientInfo, AddPatientDto>();
            CreateMap<ConsultationDto, ConsultationInfo>();
            CreateMap<ConsultationInfo, ConsultationDto>();
            CreateMap<PrescriptionInfo, PrescriptionDto>();
            CreateMap<PrescriptionDto, PrescriptionInfo>();
            CreateMap<PatientVitalsInfo, PatientVitalsDto>();
            CreateMap<PatientVitalsDto, PatientVitalsInfo>();
                
        }
    }   
  
}
