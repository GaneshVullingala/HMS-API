using Microsoft.Identity.Client;

namespace EcommerceApi.DTO
{
    public class ConsultationDto
    {
        public int ConsultId { get; set; }
        public string CurrentStatus { get; set; }
        public string Diognosis { get; set; }
        public string Problem { get; set; }
        public string Advice { get; set; }
        public DateTime RevisitDate { get; set; }   

    }
}
