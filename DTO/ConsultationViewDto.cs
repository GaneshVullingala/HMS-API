using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.DTO
{
    public class ConsultationViewDto
    {
        [Key]
        public int ConsultId { get; set; }

        public int PatientGenId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }

        public int DoctorId { get; set; }

        public string DoctorName { get; set; }
        public int FrontDeskId { get; set; }
        public string FrontDeskName { get; set; }


        public string CurrentStatus { get; set; }
        public string Diognosis { get; set; }
        public string Problem { get; set; }
        public string Advice { get; set; }
        public DateTime? RevisitDate { get; set; }
        public decimal Fee { get; set; }

        public DateTime ConsultationCreatedOn { get; set; } 
        public string PresentProblem { get; set; }
        public string PreviousHistory { get; set; }
       
        // Vitals
        public string BP { get; set; }
        public string Sugar { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string SPO2 { get; set; }

        public DateTime VitalsCreatedOn { get; set; }   
    }
}
