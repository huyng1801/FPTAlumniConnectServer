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
    public class SessionController : ControllerBase
    {
        private static List<Session> _sessions = new List<Session>();
        private static int _nextId = 1;

        // POST: api/session
        [HttpPost]
        public async Task<ActionResult<SessionResponse>> CreateSession([FromBody] SessionDTO sessionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var session = new Session
            {
                Id = _nextId++,
                MentorshipId = sessionDto.MentorshipId,
                ScheduledTime = sessionDto.ScheduledTime,
                Content = sessionDto.Content,
                IsAnswered = sessionDto.IsAnswered
            };

            _sessions.Add(session);

            var response = new SessionResponse
            {
                Id = session.Id,
                MentorshipId = session.MentorshipId,
                ScheduledTime = session.ScheduledTime,
                Content = session.Content,
                IsAnswered = session.IsAnswered
            };

            return CreatedAtAction(nameof(GetSessionById), new { id = session.Id }, response);
        }

        // GET: api/session/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SessionResponse>> GetSessionById(int id)
        {
            var session = _sessions.FirstOrDefault(s => s.Id == id);

            if (session == null)
            {
                return NotFound($"Session with ID {id} not found.");
            }

            var response = new SessionResponse
            {
                Id = session.Id,
                MentorshipId = session.MentorshipId,
                ScheduledTime = session.ScheduledTime,
                Content = session.Content,
                IsAnswered = session.IsAnswered
            };

            return Ok(response);
        }

        // PUT: api/session/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<SessionResponse>> UpdateSession(int id, [FromBody] SessionDTO sessionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var session = _sessions.FirstOrDefault(s => s.Id == id);
            if (session == null)
            {
                return NotFound($"Session with ID {id} not found.");
            }

            session.MentorshipId = sessionDto.MentorshipId;
            session.ScheduledTime = sessionDto.ScheduledTime;
            session.Content = sessionDto.Content;
            session.IsAnswered = sessionDto.IsAnswered;

            var response = new SessionResponse
            {
                Id = session.Id,
                MentorshipId = session.MentorshipId,
                ScheduledTime = session.ScheduledTime,
                Content = session.Content,
                IsAnswered = session.IsAnswered
            };

            return Ok(response);
        }

        // GET: api/session/byMentorship/{mentorshipId}
        [HttpGet("byMentorship/{mentorshipId}")]
        public async Task<ActionResult<IEnumerable<SessionResponse>>> GetSessionsByMentorshipId(int mentorshipId)
        {
            var sessions = _sessions.Where(s => s.MentorshipId == mentorshipId).ToList();

            if (!sessions.Any())
            {
                return NotFound($"No sessions found for Mentorship ID {mentorshipId}");
            }

            var responses = sessions.Select(session => new SessionResponse
            {
                Id = session.Id,
                MentorshipId = session.MentorshipId,
                ScheduledTime = session.ScheduledTime,
                Content = session.Content,
                IsAnswered = session.IsAnswered
            }).ToList();

            return Ok(responses);
        }
    }
}
