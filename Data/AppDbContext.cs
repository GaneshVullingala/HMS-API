using EcommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<RoleInfo> tblRoleInfo { get; set; }
        public DbSet<PrescriptionInfo> tblprescriptionInfo { get; set; }
        public DbSet<PatientVitalsInfo> tblPatientVitalsInfo { get;set; }
        public DbSet<PatientVisitInfo> tblPatientVisitInfo { get; set; }
        public DbSet<PatientInfo> tblPatientInfo { get; set; }
        public DbSet<GeneralInfo> tblGeneralInfo { get; set; }
        public DbSet<FrontDeskInfo> tblFrontDeskInfo { get; set; }
        public DbSet<DoctorInfo> tblDoctorInfo { get; set; }
        public DbSet<ConsultationInfo> tblConsultationInfo { get; set; }
        public DbSet<CommunicationInfo> tblCommunicationInfo { get; set; }
    }
}
