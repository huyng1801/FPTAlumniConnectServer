namespace FPTAlumniConnectServer.Entities
{
    public partial class Notifications
    {
        public int NotificationID { get; set; }
        public int ReceiverID { get; set; }
        public int Notification_Object_Id { get; set; }
        public bool IsRead { get; set; }
        public string Status { get; set; }
        public System.DateTime CreatedAt { get; set; }
    }
}
