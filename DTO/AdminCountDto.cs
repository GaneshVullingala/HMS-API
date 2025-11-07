namespace EcommerceApi.DTO
{
    public class AdminCountDto
    {
        public int AllConsultations { get; set; }
        public int PendingConsultations { get; set; }
        public int CompletedConsultations { get; set; }
        public int TotalFeeCollected { get; set; }
        public int TotalPatientRegistered { get; set; }
        public int TotalDoctors { get; set; }
        public int TotalFrontDesks { get; set; }
        public int TotalProfit { get; set; }
    }
}
