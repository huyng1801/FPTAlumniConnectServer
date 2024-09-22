namespace FPTAlumniConnectServer.Entities
{
    public class MentorshipFeedback
    {
        public int Id { get; set; }
        public int MentorshipId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual MentorshipRequest MentorshipRequest { get; set; }
    }
}
