using Microsoft.AspNetCore.Mvc;
using FPTAlumniConnectServer.Entities;
using FPTAlumniConnectServer.DTOs;
using FPTAlumniConnectServer.Response;
using System.Collections.Generic;
using System.Linq;
using FPTAlumniConnectServer.Data;
using FPTAlumniConnectServer.Response;

namespace FPTAlumniConnectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotificationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create a new notification
        [HttpPost]
        public IActionResult CreateNotification([FromBody] NotificationDTO dto)
        {
            var notification = new Notification
            {
                NotificationType = dto.NotificationType,
                RecipientUserId = dto.RecipientUserId,
                SenderUserId = dto.SenderUserId,
                Message = dto.Message,
                IsRead = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RelatedEntity = dto.RelatedEntity,
                RelatedEntityId = dto.RelatedEntityId
            };

            _context.Notifications.Add(notification);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetNotificationById), new { id = notification.Id }, new NotificationResponse
            {
                Id = notification.Id,
                NotificationType = notification.NotificationType.ToString(),
                RecipientUserId = notification.RecipientUserId,
                SenderUserId = notification.SenderUserId,
                Message = notification.Message,
                IsRead = notification.IsRead,
                CreatedAt = notification.CreatedAt,
                UpdatedAt = notification.UpdatedAt,
                RelatedEntity = notification.RelatedEntity,
                RelatedEntityId = notification.RelatedEntityId
            });
        }

        // Get notification by ID
        [HttpGet("{id}")]
        public IActionResult GetNotificationById(int id)
        {
            var notification = _context.Notifications.Find(id);
            if (notification == null)
            {
                return NotFound();
            }

            return Ok(new NotificationResponse
            {
                Id = notification.Id,
                NotificationType = notification.NotificationType.ToString(),
                RecipientUserId = notification.RecipientUserId,
                SenderUserId = notification.SenderUserId,
                Message = notification.Message,
                IsRead = notification.IsRead,
                CreatedAt = notification.CreatedAt,
                UpdatedAt = notification.UpdatedAt,
                RelatedEntity = notification.RelatedEntity,
                RelatedEntityId = notification.RelatedEntityId
            });
        }

        // Get notifications for a user
        [HttpGet("GetByUserId/{userId}")]
        public IActionResult GetNotificationsByUserId(int userId)
        {
            var notifications = _context.Notifications
                .Where(n => n.RecipientUserId == userId)
                .Select(n => new NotificationResponse
                {
                    Id = n.Id,
                    NotificationType = n.NotificationType.ToString(),
                    RecipientUserId = n.RecipientUserId,
                    SenderUserId = n.SenderUserId,
                    Message = n.Message,
                    IsRead = n.IsRead,
                    CreatedAt = n.CreatedAt,
                    UpdatedAt = n.UpdatedAt,
                    RelatedEntity = n.RelatedEntity,
                    RelatedEntityId = n.RelatedEntityId
                }).ToList();

            if (notifications == null || notifications.Count == 0)
            {
                return NotFound($"No notifications found for user with ID {userId}");
            }

            return Ok(notifications);
        }

        // Mark notification as read
        [HttpPut("{id}/mark-as-read")]
        public IActionResult MarkAsRead(int id)
        {
            var notification = _context.Notifications.Find(id);
            if (notification == null)
            {
                return NotFound();
            }

            notification.IsRead = true;
            notification.UpdatedAt = DateTime.UtcNow;
            _context.SaveChanges();

            return NoContent();
        }
    }
}
