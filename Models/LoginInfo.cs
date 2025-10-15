using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApi.Models
{
    public class LoginInfo
    {
        public int Id { get; set; }
        public int Genid { get; set; }
        [ForeignKey("Genid")]
        public GeneralInfo GeneralInfo { get; set; }

        public string Role { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Username { get; set; }
        public string Password { get; set; }

        public int UserId { get; set; } // This is the individual user id from respective table (like DoctorId, PatientId, etc.)
    }
}
