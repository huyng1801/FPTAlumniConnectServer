namespace FPTAlumniConnectServer.Entities
{
    public partial class GroupChat
    {
        public int Id { get; set; }
        public string RecentName { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
    }
}
