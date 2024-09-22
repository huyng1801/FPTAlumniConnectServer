namespace FPTAlumniConnectServer.Entities
{
    public class UserJoinEvent
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Rating { get; set; }
        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
