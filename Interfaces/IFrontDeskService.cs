using EcommerceApi.DTO;

namespace EcommerceApi.Interfaces
{
    public interface IFrontDeskService
    {
        Task<AddFrontDeskDTO> AddFrontDeskAsync(AddFrontDeskDTO frontDeskDTO);
    }
}
