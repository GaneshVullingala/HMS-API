using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Models
{
    public class PatientInfo
    {
        [Key]
        public int PatientId { get; set; }
        public int Genid { get; set; }
        public int FrontdeskId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PresentProblem { get; set; }
        public string PreviousHistory { get; set; }

        public string Address { get; set; }
        public string Pincode { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
