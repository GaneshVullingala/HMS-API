using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApi.Models
{
    public class CommunicationInfo
    {
        [Key]
        public int CommId { get; set; }
        public int GenId { get; set; }
        [ForeignKey("GenId")]
        public GeneralInfo GeneralInfo { get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
    }
}
