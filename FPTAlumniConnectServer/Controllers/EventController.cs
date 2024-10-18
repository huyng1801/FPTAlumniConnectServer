using FPTAlumniConnectServer.DTOs;
using FPTAlumniConnectServer.Entities;
using FPTAlumniConnectServer.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FPTAlumniConnectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private static List<Event> _events = new List<Event>();
        private static int _nextId = 1;

        public EventController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        // POST: api/event
        [HttpPost]
        public async Task<ActionResult<EventResponse>> CreateEvent([FromForm] EventDTO eventDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Handle image upload
            string imageUrl = null;
            if (eventDto.Image != null)
            {
                var imagePath = Path.Combine(_environment.WebRootPath, "uploads", eventDto.Image.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await eventDto.Image.CopyToAsync(stream);
                }
                imageUrl = $"/uploads/{eventDto.Image.FileName}";
            }

            var newEvent = new Event
            {
                Id = _nextId++,
                EventName = eventDto.EventName,
                Description = eventDto.Description,
                ImageUrl = imageUrl, // Save the URL for the image
                StartDate = eventDto.StartDate,
                EndDate = eventDto.EndDate,
                Location = eventDto.Location,
                IsHide = eventDto.IsHide,
                UserId = eventDto.UserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _events.Add(newEvent);

            var response = new EventResponse
            {
                Id = newEvent.Id,
                EventName = newEvent.EventName,
                Description = newEvent.Description,
                ImageUrl = newEvent.ImageUrl,
                StartDate = newEvent.StartDate,
                EndDate = newEvent.EndDate,
                Location = newEvent.Location,
                IsHide = newEvent.IsHide,
                CreatedAt = newEvent.CreatedAt,
                UpdatedAt = newEvent.UpdatedAt,
                UserId = newEvent.UserId
            };

            return CreatedAtAction(nameof(GetEventById), new { id = newEvent.Id }, response);
        }

        // GET: api/event/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EventResponse>> GetEventById(int id)
        {
            var eventItem = _events.FirstOrDefault(e => e.Id == id);

            if (eventItem == null)
            {
                return NotFound($"Event with ID {id} not found.");
            }

            var response = new EventResponse
            {
                Id = eventItem.Id,
                EventName = eventItem.EventName,
                Description = eventItem.Description,
                ImageUrl = eventItem.ImageUrl,
                StartDate = eventItem.StartDate,
                EndDate = eventItem.EndDate,
                Location = eventItem.Location,
                IsHide = eventItem.IsHide,
                CreatedAt = eventItem.CreatedAt,
                UpdatedAt = eventItem.UpdatedAt,
                UserId = eventItem.UserId
            };

            return Ok(response);
        }

        // PUT: api/event/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<EventResponse>> UpdateEvent(int id, [FromForm] EventDTO eventDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventItem = _events.FirstOrDefault(e => e.Id == id);
            if (eventItem == null)
            {
                return NotFound($"Event with ID {id} not found.");
            }

            // Handle image upload
            string imageUrl = eventItem.ImageUrl; // Use existing imageUrl if no new image is provided
            if (eventDto.Image != null)
            {
                var imagePath = Path.Combine(_environment.WebRootPath, "uploads", eventDto.Image.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await eventDto.Image.CopyToAsync(stream);
                }
                imageUrl = $"/uploads/{eventDto.Image.FileName}";
            }

            // Update event details
            eventItem.EventName = eventDto.EventName;
            eventItem.Description = eventDto.Description;
            eventItem.ImageUrl = imageUrl;
            eventItem.StartDate = eventDto.StartDate;
            eventItem.EndDate = eventDto.EndDate;
            eventItem.Location = eventDto.Location;
            eventItem.IsHide = eventDto.IsHide;
            eventItem.UpdatedAt = DateTime.UtcNow;
            eventItem.UserId = eventDto.UserId;

            var response = new EventResponse
            {
                Id = eventItem.Id,
                EventName = eventItem.EventName,
                Description = eventItem.Description,
                ImageUrl = eventItem.ImageUrl,
                StartDate = eventItem.StartDate,
                EndDate = eventItem.EndDate,
                Location = eventItem.Location,
                IsHide = eventItem.IsHide,
                CreatedAt = eventItem.CreatedAt,
                UpdatedAt = eventItem.UpdatedAt,
                UserId = eventItem.UserId
            };

            return Ok(response);
        }

        // GET: api/event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventResponse>>> GetAllEvents()
        {
            var response = _events.Select(eventItem => new EventResponse
            {
                Id = eventItem.Id,
                EventName = eventItem.EventName,
                Description = eventItem.Description,
                ImageUrl = eventItem.ImageUrl,
                StartDate = eventItem.StartDate,
                EndDate = eventItem.EndDate,
                Location = eventItem.Location,
                IsHide = eventItem.IsHide,
                CreatedAt = eventItem.CreatedAt,
                UpdatedAt = eventItem.UpdatedAt,
                UserId = eventItem.UserId
            }).ToList();

            return Ok(response);
        }
    }
}
