using FPTAlumniConnectServer.Entities;

namespace FPTAlumniConnectServer.Response
{
    public class NotificationResponse
    {
        public int Id { get; set; }
        public string NotificationType { get; set; }
        public int RecipientUserId { get; set; }
        public int? SenderUserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public RelatedEntityEnum? RelatedEntity { get; set; }
        public int? RelatedEntityId { get; set; }
    }
}
