namespace EcommerceApi.DTO
{
    public class AddDoctorDto
    {
        public required string FullName { get; set; }

        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required string Qualification { get; set; }
        public required string Speciality { get; set; }
        public int Experience { get; set; }
        public string PhotoImgUrl { get; set; }
        public string DocImgUrl { get; set; }
        public required string Address { get; set; }
        public required string Pincode { get; set; }
    }
}
