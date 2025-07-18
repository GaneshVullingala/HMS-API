using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IFrontDeskRepository
    {
        Task<FrontDeskInfo> AddFrontDesk(FrontDeskInfo frontDeskInfo, GeneralInfo generalInfo);
    }
}
