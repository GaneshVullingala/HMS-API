using EcommerceApi.Data;
using EcommerceApi.DTO;
using EcommerceApi.Interfaces;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;

namespace EcommerceApi.Controllers
{

    [Authorize(Roles = "Admin, FrontDesk")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IDoctorService _doctorservice;
        private readonly IFrontDeskService _frontdeskservice;
        private readonly IPatientService _patientservice;


        public AdminController(IDoctorService doctorservice , IFrontDeskService frontDeskService, IPatientService patientService)
        {
            _doctorservice = doctorservice;
            _frontdeskservice = frontDeskService;
            _patientservice = patientService;
        }


        [HttpPost("doctor")]
        public async Task<IActionResult> AddDoctor([FromForm] AddDoctorDto addDoctorDto)
        {
            var DoctorEntity = await _doctorservice.AddDoctorAsync(addDoctorDto);
            return Ok(DoctorEntity);
        }


        [HttpGet("doctor")]
        public async Task<IActionResult> GetAllDoctors()
        {
            var AllDoctorsList = await _doctorservice.GetAllDoctorAsync();
            return Ok(AllDoctorsList);
        }


        [HttpGet("doctor/id/{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var DoctorEntity = await _doctorservice.GetDoctorByIdAsync(id);
            if (DoctorEntity == null) return NotFound();
            return Ok(DoctorEntity);
        }


        [HttpGet("doctor/name/{name}")]
        public async Task<IActionResult> GetDoctorByName(string name)
        {
            var DoctorsList = await _doctorservice.GetDoctorByNameAsync(name);
            if (DoctorsList == null) return NotFound();
            return Ok(DoctorsList);
        }


        [HttpPut("doctor/id/{id}")]
        public async Task<IActionResult> UpdateDoctorInfo(int id, [FromForm] AddDoctorDto updateDoctorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var DoctorEntity = await _doctorservice.UpdateDoctorAsync(id, updateDoctorDto);
                if (DoctorEntity == null)
                {
                    return NotFound();
                }

                return Ok(DoctorEntity);
            }
        }

        [HttpDelete("doctor/id/{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            if(id== 0)
            {
                return BadRequest();
            }
            bool istrue = await _doctorservice.DeleteDoctorAsync(id);
            if (istrue)
            {
                return Ok(new { message = "Doctor deleted successfully" });
            }
            else
            {
                return BadRequest("Doctor not found");
            }
        }
        [HttpPost("frontdesk")]
        public async Task<IActionResult> AddFrontDeskAsync([FromForm] AddFrontDeskDTO addFrontDeskDTO)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState); 
            }
            var frontdeskentity = await _frontdeskservice.AddFrontDeskAsync(addFrontDeskDTO);
            return Ok(frontdeskentity);
        }


        [HttpGet("frontdesk")]
        public async Task<IActionResult> GetAllFrontDeskAsync()
        {
            var AllFrontDeskList = await _frontdeskservice.GetAllFrontDeskInfoAsync();

            if(AllFrontDeskList== null)
            {
                return NotFound();
            }
            return Ok(AllFrontDeskList);

        }



        [HttpGet("patient")]
        public async Task<IActionResult> GetAllPatientsAsync()
        {
            var AllPatinetList = await _patientservice.GetAllPatientsAsync();
            if (AllPatinetList == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(AllPatinetList);
            }
        }


        [HttpPost("patient")]
        public async Task<IActionResult> AddPatientAsync([FromForm] AddPatientDto addPatientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var patiententity = await _patientservice.AddPatientAsync(addPatientDto);
            return Ok(patiententity);
        }


        [HttpGet("frontdesk/id/{id}")]
        public async Task<IActionResult> GetFrontDeskById(int id)
        {
            var frontdeskentity = await _frontdeskservice.GetAllFrontDeskInfoAsync();
            var frontdesk = frontdeskentity.FirstOrDefault(fd => fd.FrontDeskId == id);
            if (frontdesk == null)
            {
                return NotFound();
            }
            return Ok(frontdesk);
        }

    }
}
