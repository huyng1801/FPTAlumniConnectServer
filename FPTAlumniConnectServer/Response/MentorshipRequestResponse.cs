namespace FPTAlumniConnectServer.Response
{
    public class MentorshipRequestResponse
    {
        public int Id { get; set; }
        public int MentorId { get; set; }
        public int StudentId { get; set; }
        public string RequestMessage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsApproved { get; set; }
    }
}
