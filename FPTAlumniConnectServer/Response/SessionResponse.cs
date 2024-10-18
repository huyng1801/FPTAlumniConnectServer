namespace FPTAlumniConnectServer.Response
{
    public class SessionResponse
    {
        public int Id { get; set; }
        public int MentorshipId { get; set; }
        public DateTime ScheduledTime { get; set; }
        public string Content { get; set; }
        public bool IsAnswered { get; set; }
    }
}
