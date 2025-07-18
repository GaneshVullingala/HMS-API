namespace EcommerceApi.DTO
{
    public class AddFrontDeskDTO
    {
        public string FullName { get; set; }
        public string Qualification { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Speciality { get; set; }
        public int Experience { get; set; }
        public string PhotoImgUrl { get; set; }
        public string DocImgUrl { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public DateTime CreatedOn { get; set; }

        //public GeneralInfoDTO generalInfodto { get; set; }
    }
}
