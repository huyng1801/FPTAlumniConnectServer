using Microsoft.AspNetCore.Mvc;
using FPTAlumniConnectServer.Entities;
using FPTAlumniConnectServer.DTOs;
using FPTAlumniConnectServer.Response;
using System.Linq;
using FPTAlumniConnectServer.Data;
using FPTAlumniConnectServer.Response;

namespace FPTAlumniConnectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationSettingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotificationSettingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create or update a notification setting
        [HttpPost]
        public IActionResult CreateOrUpdateNotificationSetting([FromBody] NotificationSettingDTO dto)
        {
            var existingSetting = _context.NotificationSettings
                .FirstOrDefault(ns => ns.UserId == dto.UserId && ns.NotificationType == dto.NotificationType);

            if (existingSetting != null)
            {
                // Update existing notification setting
                existingSetting.Enable = dto.Enable;
                _context.SaveChanges();

                return Ok(new NotificationSettingResponse
                {
                    Id = existingSetting.Id,
                    UserId = existingSetting.UserId,
                    NotificationType = existingSetting.NotificationType.ToString(),
                    Enable = existingSetting.Enable,
                    UserName = existingSetting.User.Email
                });
            }
            else
            {
                // Create new notification setting
                var newSetting = new NotificationSetting
                {
                    UserId = dto.UserId,
                    NotificationType = dto.NotificationType,
                    Enable = dto.Enable
                };
                _context.NotificationSettings.Add(newSetting);
                _context.SaveChanges();

                return Ok(new NotificationSettingResponse
                {
                    Id = newSetting.Id,
                    UserId = newSetting.UserId,
                    NotificationType = newSetting.NotificationType.ToString(),
                    Enable = newSetting.Enable,
                    UserName = newSetting.User.Email
                });
            }
        }

        // Get notification settings by user id
        [HttpGet("GetByUserId/{userId}")]
        public IActionResult GetNotificationSettingsByUserId(int userId)
        {
            var settings = _context.NotificationSettings
                .Where(ns => ns.UserId == userId)
                .Select(ns => new NotificationSettingResponse
                {
                    Id = ns.Id,
                    UserId = ns.UserId,
                    NotificationType = ns.NotificationType.ToString(),
                    Enable = ns.Enable,
                    UserName = ns.User.Email
                }).ToList();

            if (settings == null || settings.Count == 0)
            {
                return NotFound($"No notification settings found for user with id {userId}");
            }

            return Ok(settings);
        }
    }
}
