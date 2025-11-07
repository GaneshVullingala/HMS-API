using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Models
{
    public class ConsultationView
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

        public string Age { get; set; }
        public string Gender { get; set; }
        public string ReferredBy { get; set; }
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
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal SPO2 { get; set; }
        public string Temperature { get; set; }
        public string BloodGroup { get; set; }

        public DateTime VitalsCreatedOn { get; set; }
    }
}
