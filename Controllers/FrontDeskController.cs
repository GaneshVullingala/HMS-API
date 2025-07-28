using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcommerceApi.Interfaces;
using EcommerceApi.DTO;

namespace EcommerceApi.Controllers
{
    [Authorize(Roles = "FrontDesk")]
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
                return Ok("Patient vitals added successfully.");
            }
            return BadRequest("Failed to add patient vitals.");
        }
    }
}
