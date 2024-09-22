namespace FPTAlumniConnectServer.Entities
{
    public class MentorshipRequest
    {
        public int Id { get; set; }
        public int MentorId { get; set; }
        public int StudentId { get; set; }
        public string RequestMessage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsApproved { get; set; }
        public virtual User Mentor { get; set; }
        public virtual User Student { get; set; }
        public virtual ICollection<MentorshipFeedback> MentorshipFeedbacks { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
