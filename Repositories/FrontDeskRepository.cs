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

        public async Task<FrontDeskInfo> AddFrontDesk(FrontDeskInfo frontDeskinfo, GeneralInfo generalInfo) 
        { 
            await _context.tblGeneralInfo.AddAsync(generalInfo);
            await _context.SaveChangesAsync();

            frontDeskinfo.GenId = generalInfo.Genid;
            await _context.tblFrontDeskInfo.AddAsync(frontDeskinfo);
            await _context.SaveChangesAsync();
            return frontDeskinfo;
        }
    }
}
