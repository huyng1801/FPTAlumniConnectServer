namespace FPTAlumniConnectServer.Response
{
    public class MentorshipFeedbackResponse
    {
        public int Id { get; set; }
        public int MentorshipId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
