using System.ComponentModel.DataAnnotations;

namespace FPTAlumniConnectServer.Entities
{
    public class NotificationSetting
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public NotificationTypeEnum NotificationType { get; set; }
        public bool Enable { get; set; }
        public virtual User User { get; set; }
    }
}
