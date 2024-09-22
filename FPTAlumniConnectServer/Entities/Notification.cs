namespace FPTAlumniConnectServer.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public NotificationTypeEnum NotificationType { get; set; }
        public int RecipientUserId { get; set; }
        public int? SenderUserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual User RecipientUser { get; set; }
        public virtual User SenderUser { get; set; }
        public int? RelatedEntityId { get; set; }
        public RelatedEntityEnum RelatedEntity { get; set; }
    }
}
