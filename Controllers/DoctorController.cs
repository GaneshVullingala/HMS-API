using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcommerceApi.DTO;
using EcommerceApi.Interfaces;

namespace EcommerceApi.Controllers
{
    [Authorize(Roles="Doctor, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpPut("UpdateConsultation")]
        public async Task<IActionResult> UpdateConultInfo([FromBody] UpdateConsultationDto consultationdto)
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

        [HttpGet("consultations/pending")]
        public async Task<IActionResult> GetPendingConsultationsByDoctor()
        {
            var userClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userClaim == null)
            {
                return Unauthorized();
            }
            else
            {
                var ResultEntity = await _doctorService.GetPendingConsultationsByDoctorId(int.Parse(userClaim.Value));
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
        [HttpGet("consultations/completed")]
        public async Task<IActionResult> GetCompletedConsultationsByDoctor()
        {
            var userClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userClaim == null)
            {
                return Unauthorized();
            }
            else
            {
                var ResultEntity = await _doctorService.GetCompletedConsultationsByDoctorId(int.Parse(userClaim.Value));
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
