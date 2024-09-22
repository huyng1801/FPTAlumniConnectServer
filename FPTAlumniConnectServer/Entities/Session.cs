namespace FPTAlumniConnectServer.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public int MentorshipId { get; set; }
        public DateTime ScheduledTime { get; set; }
        public string Content { get; set; }
        public bool IsAnswered { get; set; }
        public virtual MentorshipRequest MentorshipRequest { get; set; }
    }
}
