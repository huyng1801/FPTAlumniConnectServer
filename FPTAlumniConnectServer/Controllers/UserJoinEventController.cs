using FPTAlumniConnectServer.DTOs;
using FPTAlumniConnectServer.Entities;
using FPTAlumniConnectServer.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPTAlumniConnectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserJoinEventController : ControllerBase
    {
        private static List<UserJoinEvent> _userJoinEvents = new List<UserJoinEvent>();
        private static int _nextId = 1;

        // POST: api/userjoinevent
        [HttpPost]
        public async Task<ActionResult<UserJoinEventResponse>> JoinEvent([FromBody] UserJoinEventDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userJoinEvent = new UserJoinEvent
            {
                Id = _nextId++,
                UserId = dto.UserId,
                EventId = dto.EventId,
                Content = dto.Content,
                Rating = dto.Rating,
                CreatedAt = DateTime.UtcNow
            };

            _userJoinEvents.Add(userJoinEvent);

            var response = new UserJoinEventResponse
            {
                Id = userJoinEvent.Id,
                UserId = userJoinEvent.UserId,
                EventId = userJoinEvent.EventId,
                Content = userJoinEvent.Content,
                Rating = userJoinEvent.Rating,
                CreatedAt = userJoinEvent.CreatedAt,
                UserName = $"User_{userJoinEvent.UserId}", // Placeholder for user name
                EventName = $"Event_{userJoinEvent.EventId}" // Placeholder for event name
            };

            return CreatedAtAction(nameof(GetUserJoinEventById), new { id = userJoinEvent.Id }, response);
        }

        // GET: api/userjoinevent/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserJoinEventResponse>> GetUserJoinEventById(int id)
        {
            var userJoinEvent = _userJoinEvents.FirstOrDefault(uje => uje.Id == id);

            if (userJoinEvent == null)
            {
                return NotFound($"UserJoinEvent with ID {id} not found.");
            }

            var response = new UserJoinEventResponse
            {
                Id = userJoinEvent.Id,
                UserId = userJoinEvent.UserId,
                EventId = userJoinEvent.EventId,
                Content = userJoinEvent.Content,
                Rating = userJoinEvent.Rating,
                CreatedAt = userJoinEvent.CreatedAt,
                UserName = $"User_{userJoinEvent.UserId}", // Placeholder for user name
                EventName = $"Event_{userJoinEvent.EventId}" // Placeholder for event name
            };

            return Ok(response);
        }

        // GET: api/userjoinevent/event/{eventId}
        [HttpGet("event/{eventId}")]
        public async Task<ActionResult<IEnumerable<UserJoinEventResponse>>> GetAllUsersForEvent(int eventId)
        {
            var userJoinEvents = _userJoinEvents.Where(uje => uje.EventId == eventId).ToList();

            if (userJoinEvents == null || !userJoinEvents.Any())
            {
                return NotFound($"No users found for event with ID {eventId}.");
            }

            var response = userJoinEvents.Select(uje => new UserJoinEventResponse
            {
                Id = uje.Id,
                UserId = uje.UserId,
                EventId = uje.EventId,
                Content = uje.Content,
                Rating = uje.Rating,
                CreatedAt = uje.CreatedAt,
                UserName = $"User_{uje.UserId}", // Placeholder for user name
                EventName = $"Event_{uje.EventId}" // Placeholder for event name
            }).ToList();

            return Ok(response);
        }

        // PUT: api/userjoinevent/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<UserJoinEventResponse>> UpdateUserJoinEvent(int id, [FromBody] UserJoinEventDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userJoinEvent = _userJoinEvents.FirstOrDefault(uje => uje.Id == id);
            if (userJoinEvent == null)
            {
                return NotFound($"UserJoinEvent with ID {id} not found.");
            }

            userJoinEvent.Content = dto.Content;
            userJoinEvent.Rating = dto.Rating;
            userJoinEvent.CreatedAt = DateTime.UtcNow;

            var response = new UserJoinEventResponse
            {
                Id = userJoinEvent.Id,
                UserId = userJoinEvent.UserId,
                EventId = userJoinEvent.EventId,
                Content = userJoinEvent.Content,
                Rating = userJoinEvent.Rating,
                CreatedAt = userJoinEvent.CreatedAt,
                UserName = $"User_{userJoinEvent.UserId}", // Placeholder for user name
                EventName = $"Event_{userJoinEvent.EventId}" // Placeholder for event name
            };

            return Ok(response);
        }

        // DELETE: api/userjoinevent/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserJoinEvent(int id)
        {
            var userJoinEvent = _userJoinEvents.FirstOrDefault(uje => uje.Id == id);
            if (userJoinEvent == null)
            {
                return NotFound($"UserJoinEvent with ID {id} not found.");
            }

            _userJoinEvents.Remove(userJoinEvent);

            return NoContent();
        }
    }
}
