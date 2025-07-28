namespace EcommerceApi.DTO
{
    public class PatientVitalsDto
    {
        public int PatientId { get; set; }
        public string BP { get; set; }
        public string Sugar { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal SPO2 { get; set; }
    }
}
