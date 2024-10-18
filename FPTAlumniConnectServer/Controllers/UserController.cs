using FPTAlumniConnectServer.DTOs;
using FPTAlumniConnectServer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPTAlumniConnectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // In-memory list to hold users
        private static List<UserDTO> _users = new List<UserDTO>
        {
            new UserDTO { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", EmailConfirmed = true, Role = RoleEnum.Alumni, IsMentor = false, IsActive = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new UserDTO { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", EmailConfirmed = true, Role = RoleEnum.Student, IsMentor = true, IsActive = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        };

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return Ok(_users);
        }

        // GET: api/user/role/{role}
        [HttpGet("role/{role}")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByRole(RoleEnum role)
        {
            var usersByRole = _users.Where(u => u.Role == role).ToList();
            if (!usersByRole.Any())
            {
                return NotFound($"No users found with role {role}");
            }
            return Ok(usersByRole);
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userDto.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1; // Assign new ID
            userDto.CreatedAt = DateTime.UtcNow;
            userDto.UpdatedAt = DateTime.UtcNow;
            _users.Add(userDto);

            return CreatedAtAction(nameof(GetUsers), new { id = userDto.Id }, userDto);
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDto)
        {
            if (id != userDto.Id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound($"User with ID {id} not found");
            }

            existingUser.FirstName = userDto.FirstName;
            existingUser.LastName = userDto.LastName;
            existingUser.Email = userDto.Email;
            existingUser.EmailConfirmed = userDto.EmailConfirmed;
            existingUser.ProfilePictureUrl = userDto.ProfilePictureUrl;
            existingUser.Role = userDto.Role;
            existingUser.EducationHistory = userDto.EducationHistory;
            existingUser.Major = userDto.Major;
            existingUser.IsMentor = userDto.IsMentor;
            existingUser.IsActive = userDto.IsActive;
            existingUser.UpdatedAt = DateTime.UtcNow;

            return NoContent();
        }
    }
}
