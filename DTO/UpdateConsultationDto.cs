namespace EcommerceApi.DTO
{
    public class UpdateConsultationDto
    {
        public ConsultationDto? consultationDto { get; set; }
        public List<MedicineDto>? prescription { get; set; }

    }
}
