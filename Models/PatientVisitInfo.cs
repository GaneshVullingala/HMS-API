using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApi.Models
{
    public class PatientVisitInfo
    {
        [Key]
        public int VisitId { get; set; }
        public int ConsultId { get; set; }
        [ForeignKey("ConsultId")]
        public ConsultationInfo ConsultationInfo { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public PatientInfo PatientInfo { get; set; }
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public DoctorInfo DoctorInfo { get; set; }
        public DateTime LastVisitDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
