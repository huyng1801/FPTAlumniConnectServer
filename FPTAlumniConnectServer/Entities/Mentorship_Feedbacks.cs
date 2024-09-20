namespace FPTAlumniConnectServer.Entities
{
    public partial class Mentorship_Feedbacks
    {
        public int FeedbackID { get; set; }
        public int MentorshipID { get; set; }
        public int SessionID { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public System.DateTime CreatedAt { get; set; }
    }
}
