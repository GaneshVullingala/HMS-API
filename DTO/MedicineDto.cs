namespace EcommerceApi.DTO
{
    public class MedicineDto
    {
        public string MedicineName { get; set; }
        public bool isMrngMedicine { get; set; }
        public bool isANoonMedicine { get; set; }
        public bool isNightMedicine { get; set; }
        public int MedicineQuantity { get; set; }
    }
}
