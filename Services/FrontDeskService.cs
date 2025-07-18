using EcommerceApi.DTO;
using EcommerceApi.Interfaces;
using EcommerceApi.Models;

namespace EcommerceApi.Services
{
    public class FrontDeskService : IFrontDeskService
    {
        private readonly IFrontDeskRepository _frontDeskRepository;
        public FrontDeskService(IFrontDeskRepository frontDeskRepository)
        {
            _frontDeskRepository = frontDeskRepository;
        }

        public async Task<AddFrontDeskDTO> AddFrontDeskAsync(AddFrontDeskDTO frontDeskDTO)
        {
            var GeneralinfoEntity = new GeneralInfo()
            {
                FullName = frontDeskDTO.FullName,
                Roleid = 3,
                Status = "Active",
                CreatedOn = DateTime.Now,
            };
            var FronDeskEntity = new FrontDeskInfo()
            {
                FullName = frontDeskDTO.FullName,
                Email = frontDeskDTO.Email,
                Phone = frontDeskDTO.Phone,
                Qualification = frontDeskDTO.Qualification,
                Address = frontDeskDTO.Address,
                Speciality = frontDeskDTO.Speciality,
                Experience = frontDeskDTO.Experience,
                PhotoImgUrl = frontDeskDTO.PhotoImgUrl,
                DocImgUrl = frontDeskDTO.DocImgUrl,
                Pincode = frontDeskDTO.Pincode
            };
            await _frontDeskRepository.AddFrontDesk(FronDeskEntity, GeneralinfoEntity);
            return new AddFrontDeskDTO
            {

                FullName = frontDeskDTO.FullName,
                 Email = frontDeskDTO.Email,
                Phone = frontDeskDTO.Phone,
                Qualification = frontDeskDTO.Qualification,
                Address = frontDeskDTO.Address,
            };
        }
    }
}
