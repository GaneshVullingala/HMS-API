using EcommerceApi.Data;
using EcommerceApi.Interfaces;
using EcommerceApi.Models;

namespace EcommerceApi.Repositories
{
    public class FrontDeskRepository : IFrontDeskRepository
    {
        private readonly AppDbContext _context;

        public FrontDeskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FrontDeskInfo> AddFrontDesk(FrontDeskInfo frontDeskinfo, GeneralInfo generalInfo, LoginInfo loginInfo, CommunicationInfo communicationInfo)
        {
            await _context.tblGeneralInfo.AddAsync(generalInfo);
            await _context.SaveChangesAsync();

            frontDeskinfo.GenId = generalInfo.Genid;
            frontDeskinfo.CreatedOn = DateTime.Now;
            loginInfo.Genid = generalInfo.Genid;
            communicationInfo.GenId = generalInfo.Genid;


            await _context.tblFrontDeskInfo.AddAsync(frontDeskinfo);
            await _context.SaveChangesAsync();

            await _context.tblLoginInfo.AddAsync(loginInfo);
            await _context.SaveChangesAsync();

            await _context.tblCommunicationInfo.AddAsync(communicationInfo);
            await _context.SaveChangesAsync();

            return frontDeskinfo;
        }

        public async Task<PatientInfo> AddPatient(PatientInfo patientInfo, GeneralInfo generalInfo, LoginInfo loginInfo, CommunicationInfo communicationInfo, ConsultationInfo consultationInfo)
        {

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.tblGeneralInfo.AddAsync(generalInfo);
                await _context.SaveChangesAsync();

                loginInfo.Genid = generalInfo.Genid;
                communicationInfo.GenId = generalInfo.Genid;
                patientInfo.Genid = generalInfo.Genid;
                patientInfo.CreatedOn = DateTime.Now;

                await _context.tblPatientInfo.AddAsync(patientInfo);
                await _context.SaveChangesAsync();

                consultationInfo.PatientId = patientInfo.PatientId;

                await _context.tblConsultationInfo.AddAsync(consultationInfo);
                await _context.SaveChangesAsync();

                await _context.tblLoginInfo.AddAsync(loginInfo);
                await _context.tblCommunicationInfo.AddAsync(communicationInfo);
         

                var Patientvisitinfo = new PatientVisitInfo
                {
                    PatientId = patientInfo.PatientId,
                    DoctorId = consultationInfo.DoctorId,
                    ConsultId = consultationInfo.ConsultId,
                    CreatedOn = DateTime.Now,
                    LastVisitDate = consultationInfo.CreatedOn
                };

                await _context.tblPatientVisitInfo.AddAsync(Patientvisitinfo);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return patientInfo;

            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

        }
        public async Task<int> AddPatientVitals(PatientVitalsInfo patientVitalsInfo)
        {
            patientVitalsInfo.CreatedOn = DateTime.Now;
            await _context.tblPatientVitalsInfo.AddAsync(patientVitalsInfo);
            await _context.SaveChangesAsync();
            return patientVitalsInfo.PatientId;
        }
    }
}
