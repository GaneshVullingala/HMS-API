using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Models
{
    public class ConsultationInfo
    {
        [Key]
        public int ConsultId { get; set; }
        public int PatientId { get; set; }
        public PatientInfo PatientInfo { get; set; }
        public int DoctorId { get; set; }
        public DoctorInfo DoctorInfo { get; set; }
        public int FrontDeskId { get; set; }
        public FrontDeskInfo FrontDeskInfo { get; set; }
        public string CurrentStatus { get; set; }
        public string Diognosis { get; set; }
        public string Problem { get; set; }
        public string Advice { get; set; }

        public DateTime RevisitDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
