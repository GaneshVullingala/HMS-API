using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApi.Models
{
    public class PatientVitalsInfo
    {
        [Key]
        public int VitalsId { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public PatientInfo PatientInfo { get; set; }
        public string BP { get; set; }
        public string Sugar { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal SPO2 { get; set; }
        public DateTime CreatedOn { get; set; }

        public string Temperature { get; set; }

        public string BloodGroup { get; set; }
    }
}
