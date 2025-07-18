using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApi.Models
{
    public class GeneralInfo
    {
        [Key]
        public int Genid { get; set; }
    
        public int Roleid { get; set; } // This will be used as FK
        [ForeignKey("Roleid")]
        public RoleInfo RoleInfo { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }
}
