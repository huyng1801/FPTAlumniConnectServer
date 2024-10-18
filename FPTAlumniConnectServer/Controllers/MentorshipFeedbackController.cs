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
    public class MentorshipFeedbackController : ControllerBase
    {
        private static List<MentorshipFeedback> _feedbacks = new List<MentorshipFeedback>();
        private static int _nextId = 1; // Simple ID generator

        // POST: api/mentorshipfeedback
        [HttpPost]
        public async Task<ActionResult<MentorshipFeedbackResponse>> CreateFeedback([FromBody] MentorshipFeedbackDTO feedbackDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feedback = new MentorshipFeedback
            {
                Id = _nextId++,
                MentorshipId = feedbackDto.MentorshipId,
                Content = feedbackDto.Content,
                Rating = feedbackDto.Rating,
                CreatedAt = DateTime.UtcNow
            };

            _feedbacks.Add(feedback);

            var response = new MentorshipFeedbackResponse
            {
                Id = feedback.Id,
                MentorshipId = feedback.MentorshipId,
                Content = feedback.Content,
                Rating = feedback.Rating,
                CreatedAt = feedback.CreatedAt
            };

            return CreatedAtAction(nameof(GetFeedbackById), new { id = feedback.Id }, response);
        }

        // GET: api/mentorshipfeedback/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MentorshipFeedbackResponse>> GetFeedbackById(int id)
        {
            var feedback = _feedbacks.FirstOrDefault(f => f.Id == id);

            if (feedback == null)
            {
                return NotFound($"Feedback with ID {id} not found");
            }

            var response = new MentorshipFeedbackResponse
            {
                Id = feedback.Id,
                MentorshipId = feedback.MentorshipId,
                Content = feedback.Content,
                Rating = feedback.Rating,
                CreatedAt = feedback.CreatedAt
            };

            return Ok(response);
        }

        // PUT: api/mentorshipfeedback/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<MentorshipFeedbackResponse>> UpdateFeedback(int id, [FromBody] MentorshipFeedbackDTO feedbackDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feedback = _feedbacks.FirstOrDefault(f => f.Id == id);
            if (feedback == null)
            {
                return NotFound($"Feedback with ID {id} not found");
            }

            feedback.MentorshipId = feedbackDto.MentorshipId;
            feedback.Content = feedbackDto.Content;
            feedback.Rating = feedbackDto.Rating;

            var response = new MentorshipFeedbackResponse
            {
                Id = feedback.Id,
                MentorshipId = feedback.MentorshipId,
                Content = feedback.Content,
                Rating = feedback.Rating,
                CreatedAt = feedback.CreatedAt
            };

            return Ok(response);
        }

        // GET: api/mentorshipfeedback
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MentorshipFeedbackResponse>>> GetAllFeedback()
        {
            var responses = _feedbacks.Select(feedback => new MentorshipFeedbackResponse
            {
                Id = feedback.Id,
                MentorshipId = feedback.MentorshipId,
                Content = feedback.Content,
                Rating = feedback.Rating,
                CreatedAt = feedback.CreatedAt
            }).ToList();

            return Ok(responses);
        }

        // GET: api/mentorshipfeedback/byMentorship/{mentorshipId}
        [HttpGet("byMentorship/{mentorshipId}")]
        public async Task<ActionResult<IEnumerable<MentorshipFeedbackResponse>>> GetFeedbackByMentorshipId(int mentorshipId)
        {
            var feedbackList = _feedbacks.Where(f => f.MentorshipId == mentorshipId).ToList();

            if (!feedbackList.Any())
            {
                return NotFound($"No feedback found for Mentorship ID {mentorshipId}");
            }

            var responses = feedbackList.Select(feedback => new MentorshipFeedbackResponse
            {
                Id = feedback.Id,
                MentorshipId = feedback.MentorshipId,
                Content = feedback.Content,
                Rating = feedback.Rating,
                CreatedAt = feedback.CreatedAt
            }).ToList();

            return Ok(responses);
        }
    }
}
