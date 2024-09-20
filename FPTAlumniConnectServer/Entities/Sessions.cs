namespace FPTAlumniConnectServer.Entities
{
    public partial class Sessions
    {
        public int SessionID { get; set; }
        public int MentorID { get; set; }
        public int StudentID { get; set; }
        public System.DateTime ScheduledTime { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
    }
}
