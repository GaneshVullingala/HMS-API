using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcommerceApi.Interfaces;
using EcommerceApi.DTO;

namespace EcommerceApi.Controllers
{

    [Authorize(Roles = "FrontDesk, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class FrontDeskController : ControllerBase
    {
        private readonly IFrontDeskService _frontDeskService;

        public FrontDeskController(IFrontDeskService frontDeskService)
        {
            _frontDeskService = frontDeskService;
        }

        [HttpPost("AddPatient")]
        public async Task<IActionResult> AddPatient([FromBody] AddPatientDto patientDto)
        {
            if (patientDto == null)
            {
                return BadRequest("Invalid front desk data.");
            }
            var result = await _frontDeskService.AddPatientAsync(patientDto);
            return Ok(result);
        }

        [HttpPost("AddPatientVitals")]
        public async Task<IActionResult> AddPatientVitals([FromBody] PatientVitalsDto patientVitalsDto)
        {
            if (patientVitalsDto == null)
            {
                return BadRequest("Invalid patient vitals data.");
            }
            var result = await _frontDeskService.AddPatinetVitals(patientVitalsDto);
            if (result)
            {
                return Ok(new { message = "Patient vitals added successfully." });
            }
            return BadRequest("Failed to add patient vitals.");
        }

       [HttpGet("PatientVitals/{id}")]
       public async Task<IActionResult> GetVitalsById(int id)
        {
            var result = await _frontDeskService.GetPatientVitalsById(id);
            return Ok(result);
        }


        [HttpPost("AddConsult")]
        public async Task<IActionResult> AddPatientConsultationAsync([FromBody] ConsultationDto consultationDto)
        {
            // Get logged-in FrontDesk user ID from claims
            var userClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userClaim == null)
            {
                return Unauthorized("UserId claim not found.");
            }

            consultationDto.FrontDeskId = int.Parse(userClaim.Value);

            var entity = await _frontDeskService.AddConsultationAsync(consultationDto);
            return Ok(entity);
        }

        [HttpGet("Patient/{patientId}")]
        public async Task<IActionResult> GetPatientById(int patientId)
        {
            var result = await _frontDeskService.GetPatientByIdAsync(patientId);
            return Ok(result);
        }
    }
}
