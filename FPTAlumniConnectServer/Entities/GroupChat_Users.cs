namespace FPTAlumniConnectServer.Entities
{
    public partial class GroupChat_Users
    {
        public int Id { get; set; }
        public int GroupChatId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public System.DateTime CreatedAt { get; set; }

        public virtual GroupChat GroupChat { get; set; }
    }
}
