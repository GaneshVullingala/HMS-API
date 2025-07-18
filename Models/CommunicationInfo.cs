using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Models
{
    public class CommunicationInfo
    {
        [Key]
        public int CommId { get; set; }
        public int GenId { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
    }
}
