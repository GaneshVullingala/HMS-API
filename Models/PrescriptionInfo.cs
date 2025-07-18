using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Models
{
    public class PrescriptionInfo
    {
        [Key]
        public int PrescriptionId { get; set; }
        public int ConsultId { get; set; }
        public ConsultationInfo ConsultationInfo { get; set; }
        public int PatientId { get; set; }
        public PatientInfo PatientInfo { get; set; }
        public int DoctorId { get; set; }
        public DoctorInfo DoctorInfo { get; set; }
        public string Medicine1 { get; set; }
        public int isMrngMedicine1 { get; set; }
        public int isANoonMedicine1 { get; set; }
        public int isNightMedicine1 { get; set; }

        public int Medicine1Quantity { get; set; }
        public string Medicine2 { get; set; }
        public int isMrngMedicine2 { get; set; }
        public int isANoonMedicine2 { get; set; }
        public int isNightMedicine2 { get; set; }
        public int Medicine2Quantity { get; set; }
        public string Medicine3 { get; set; }
        public int isMrngMedicine3 { get; set; }
        public int isANoonMedicine3 { get; set; }
        public int isNightMedicine3 { get; set; }
        public int Medicine3Quantity { get; set; }
        public string Medicine4 { get; set; }
        public int isMrngMedicine4 { get; set; }
        public int isANoonMedicine4 { get; set; }
        public int isNightMedicine4 { get; set; }
        public int Medicine4Quantity { get; set; }
        public string Medicine5 { get; set; }
        public int isMrngMedicine5 { get; set; }
        public int isANoonMedicine5 { get; set; }
        public int isNightMedicine5 { get; set; }
        public int Medicine5Quantity { get; set; }
    }
}
