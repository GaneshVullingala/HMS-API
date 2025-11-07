namespace EcommerceApi.Models
{
    public class MedicineInfo
    {
        public int Id { get; set; }
        public int ConsultId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string MedicineName { get; set; }
        public bool isMrngMedicine { get; set; }
        public bool isANoonMedicine { get; set; }
        public bool isNightMedicine { get; set; }
        public int MedicineQuantity { get; set; }

        public DateTime createdOn { get; set; }
    }
}
