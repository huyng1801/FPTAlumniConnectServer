namespace FPTAlumniConnectServer.Entities
{
    public partial class NotificationSettings
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool ReceiveEmailOnNewNotification { get; set; }
        public bool ReceiveSMSOnNewNotification { get; set; }
        public bool NotifyOnNewApplications { get; set; }
        public bool MessageNotifications { get; set; }
    }
}
