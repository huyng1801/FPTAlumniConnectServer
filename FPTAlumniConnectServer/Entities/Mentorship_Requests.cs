namespace FPTAlumniConnectServer.Entities
{
    public partial class Mentorship_Requests
    {
        public int MentorshipID { get; set; }
        public int StudentID { get; set; }
        public int UserID { get; set; }
        public string RequestMessage { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public string Status { get; set; }
    }
}
