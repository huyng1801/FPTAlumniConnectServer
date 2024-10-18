namespace FPTAlumniConnectServer.Response
{
    public class NotificationSettingResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NotificationType { get; set; }
        public bool Enable { get; set; }
        public string UserName { get; set; }
    }
}
