using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Models
{
    public class RoleInfo
    {
        [Key]
        public int RoledId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
