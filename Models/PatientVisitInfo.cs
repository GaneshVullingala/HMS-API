using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Models
{
    public class PatientVisitInfo
    {
        [Key]
        public int VisitId { get; set; }
        public int ConsultId { get; set; }
        public ConsultationInfo ConsultationInfo { get; set; }
        public int PatientId { get; set; }
        public PatientInfo PatientInfo { get; set; }
        public int DoctorId { get; set; }
        public DoctorInfo DoctorInfo { get; set; }
        public DateTime LastVisitDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
