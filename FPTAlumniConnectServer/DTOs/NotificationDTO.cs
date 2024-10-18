using FPTAlumniConnectServer.Entities;
using System.ComponentModel.DataAnnotations;

namespace FPTAlumniConnectServer.DTOs
{
    public class NotificationDTO
    {
        [Required]
        public NotificationTypeEnum NotificationType { get; set; }

        [Required]
        public int RecipientUserId { get; set; }

        public int? SenderUserId { get; set; }

        [Required]
        public string Message { get; set; }

        public RelatedEntityEnum RelatedEntity { get; set; }

        public int? RelatedEntityId { get; set; }
    }
}
