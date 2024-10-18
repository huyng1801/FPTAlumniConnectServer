namespace FPTAlumniConnectServer.DTOs
{
    public class SessionDTO
    {
        public int MentorshipId { get; set; }
        public DateTime ScheduledTime { get; set; }
        public string Content { get; set; }
        public bool IsAnswered { get; set; }
    }
}
