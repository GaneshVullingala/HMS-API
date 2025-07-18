using EcommerceApi.DTO;
using EcommerceApi.Interfaces;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _service.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GerRolebyID(int id)
        {
            var role = await _service.GetRolebyIdAsync(id);
            if (role == null) return NotFound();
            return Ok(role);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleDto roleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdROle = await _service.AddAsync(roleDto);
            return Ok(createdROle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoleDto roleDto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            } 
            try
            {
                var updated = await _service.UpdateAsync(id, roleDto);
                return Ok(updated);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return Ok(new { message = "Role deleted successfully" });
        }
    }
}
