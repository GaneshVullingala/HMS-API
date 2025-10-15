using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcommerceApi.DTO;
using EcommerceApi.Interfaces;

namespace EcommerceApi.Controllers
{
    [Authorize(Roles="Doctor")]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpPut("UpdateConsult")]
        public async Task<IActionResult> UpdateConultInfo([FromBody] ConsultationDto consultationdto)
        {
            var result = await _doctorService.UpdateConsultationInfoAsync(consultationdto);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Consultation info not found.");
        }

        [HttpPost("AddPrescription")]
        public async Task<IActionResult> AddPrescription([FromBody] PrescriptionDto prescriptiondto)
        {
            if (prescriptiondto == null)
            {
                return BadRequest("Prescription data is required.");
            }
            var result = await _doctorService.AddPrescriptionAsync(prescriptiondto);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Failed to add prescription.");
        }


        [HttpGet("consultations")]
        public async Task<IActionResult> GetConsultationsByDoctor()
        {
            var userClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userClaim == null)
            {
                return Unauthorized();
            }
            else
            {
                var ResultEntity = await _doctorService.GetConsultationsByDoctorId(int.Parse(userClaim.Value));

                if (ResultEntity != null)
                {
                    return Ok(ResultEntity);
                }
                else
                {
                    return NotFound();
                }
            }
               
        }
    }
}
