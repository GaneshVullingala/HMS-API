using EcommerceApi.Interfaces;
using EcommerceApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers
{
    [Authorize(Roles = "Admin,FrontDesk,Doctor")]
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private readonly IGeneralRepostiory _generalRepostiory;
        public GeneralController(GeneralRepostiory generalRepostiory)
        {
            _generalRepostiory = generalRepostiory;
        }

        [HttpGet("consultation/{ConsultId}")]
        public async Task<IActionResult> GetConsultationInfoByIdAsync(int ConsultId)
        {
            try
            {
                var consultation = await _generalRepostiory.GetConsultationInfoByIdAsync(ConsultId);
                if (consultation == null)
                {
                    return NotFound(new { Message = "Consultation not found" });
                }
                return Ok(consultation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }
    }
}
