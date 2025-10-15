using Microsoft.Identity.Client;

namespace EcommerceApi.DTO
{
    public class ConsultationDto
    {
        public int ConsultId { get; set; }  
        public int PatientId { get; set; }

        public int DoctorId { get; set; }
        public int FrontDeskId { get; set; }
        public string CurrentStatus { get; set; }
        public string Diognosis { get; set; }
        public string Problem { get; set; }
        public string Advice { get; set; }
        public DateTime RevisitDate { get; set; }   

        public decimal Fee { get; set; }

    }
}
