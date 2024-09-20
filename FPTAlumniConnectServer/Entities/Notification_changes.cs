namespace FPTAlumniConnectServer.Entities
{
    public partial class Notification_changes
    {
        public int Id { get; set; }
        public int Actor_Id { get; set; }
        public string Status { get; set; }
        public int Notification_Object_Id { get; set; }
    }
}
