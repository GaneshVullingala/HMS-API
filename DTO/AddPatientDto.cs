namespace EcommerceApi.DTO
{
    public class AddPatientDto
    {
        public int FrontDeskId { get; set; }
        public int DoctorId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PresentProblem { get; set; }
        public string PreviousHistory { get; set; }

        
        public string Address { get; set; }
        public string Pincode { get; set; }
        public decimal Fee { get; set; }
    }
}
