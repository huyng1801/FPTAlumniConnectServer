using FPTAlumniConnectServer.Entities;
using System.ComponentModel.DataAnnotations;

namespace FPTAlumniConnectServer.DTOs
{
    public class NotificationSettingDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public NotificationTypeEnum NotificationType { get; set; }

        [Required]
        public bool Enable { get; set; }
    }
}
