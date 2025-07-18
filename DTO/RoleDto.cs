using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.DTO
{
    public class RoleDto
    {
        [Required(ErrorMessage = "Role name is required")]
        public required string RoleName { get; set; }
        public required string Status { get; set; }
    }
}
