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
    public class MentorshipRequestsController : ControllerBase
    {
        private static List<MentorshipRequest> _mentorshipRequests = new List<MentorshipRequest>();
        private static int _nextId = 1; // Simple ID generator

        // POST: api/mentorshiprequests
        [HttpPost]
        public async Task<ActionResult<MentorshipRequestResponse>> CreateMentorshipRequest([FromBody] MentorshipRequestDTO mentorshipRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mentorshipRequest = new MentorshipRequest
            {
                Id = _nextId++,
                MentorId = mentorshipRequestDto.MentorId,
                StudentId = mentorshipRequestDto.StudentId,
                RequestMessage = mentorshipRequestDto.RequestMessage,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsApproved = false // Default to false on creation
            };

            _mentorshipRequests.Add(mentorshipRequest);

            var response = new MentorshipRequestResponse
            {
                Id = mentorshipRequest.Id,
                MentorId = mentorshipRequest.MentorId,
                StudentId = mentorshipRequest.StudentId,
                RequestMessage = mentorshipRequest.RequestMessage,
                CreatedAt = mentorshipRequest.CreatedAt,
                UpdatedAt = mentorshipRequest.UpdatedAt,
                IsApproved = mentorshipRequest.IsApproved
            };

            return CreatedAtAction(nameof(GetMentorshipRequestById), new { id = mentorshipRequest.Id }, response);
        }

        // GET: api/mentorshiprequests/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MentorshipRequestResponse>> GetMentorshipRequestById(int id)
        {
            var mentorshipRequest = _mentorshipRequests.FirstOrDefault(r => r.Id == id);

            if (mentorshipRequest == null)
            {
                return NotFound($"Mentorship request with ID {id} not found");
            }

            var response = new MentorshipRequestResponse
            {
                Id = mentorshipRequest.Id,
                MentorId = mentorshipRequest.MentorId,
                StudentId = mentorshipRequest.StudentId,
                RequestMessage = mentorshipRequest.RequestMessage,
                CreatedAt = mentorshipRequest.CreatedAt,
                UpdatedAt = mentorshipRequest.UpdatedAt,
                IsApproved = mentorshipRequest.IsApproved
            };

            return Ok(response);
        }

        // PUT: api/mentorshiprequests/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<MentorshipRequestResponse>> UpdateMentorshipRequest(int id, [FromBody] MentorshipRequestDTO mentorshipRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mentorshipRequest = _mentorshipRequests.FirstOrDefault(r => r.Id == id);
            if (mentorshipRequest == null)
            {
                return NotFound($"Mentorship request with ID {id} not found");
            }

            mentorshipRequest.MentorId = mentorshipRequestDto.MentorId;
            mentorshipRequest.StudentId = mentorshipRequestDto.StudentId;
            mentorshipRequest.RequestMessage = mentorshipRequestDto.RequestMessage;
            mentorshipRequest.UpdatedAt = DateTime.UtcNow;

            var response = new MentorshipRequestResponse
            {
                Id = mentorshipRequest.Id,
                MentorId = mentorshipRequest.MentorId,
                StudentId = mentorshipRequest.StudentId,
                RequestMessage = mentorshipRequest.RequestMessage,
                CreatedAt = mentorshipRequest.CreatedAt,
                UpdatedAt = mentorshipRequest.UpdatedAt,
                IsApproved = mentorshipRequest.IsApproved
            };

            return Ok(response);
        }

        // GET: api/mentorshiprequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MentorshipRequestResponse>>> GetAllMentorshipRequests()
        {
            var responses = _mentorshipRequests.Select(request => new MentorshipRequestResponse
            {
                Id = request.Id,
                MentorId = request.MentorId,
                StudentId = request.StudentId,
                RequestMessage = request.RequestMessage,
                CreatedAt = request.CreatedAt,
                UpdatedAt = request.UpdatedAt,
                IsApproved = request.IsApproved
            }).ToList();

            return Ok(responses);
        }
    }
}
