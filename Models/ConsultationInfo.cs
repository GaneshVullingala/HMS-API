using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApi.Models
{
    public class ConsultationInfo
    {
        [Key]
        public int ConsultId { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public PatientInfo patientInfo { get; set; }
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public DoctorInfo DoctorInfo { get; set; }

        public int FrontDeskId { get; set; }
        [ForeignKey("FrontDeskId")]
        public FrontDeskInfo FrontDeskInfo { get; set; }    
        public string CurrentStatus { get; set; }
        public string Diognosis { get; set; }
        public string Problem { get; set; }
        public string Advice { get; set; }

        public DateTime RevisitDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
