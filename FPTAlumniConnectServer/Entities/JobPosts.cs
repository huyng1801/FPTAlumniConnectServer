namespace FPTAlumniConnectServer.Entities
{
    public partial class JobPosts
    {
        public int JobPostID { get; set; }
        public string JobDescription { get; set; }
        public string Salary { get; set; }
        public string Location { get; set; }
        public string Requirements { get; set; }
        public string Benefits { get; set; }
        public string Status { get; set; }
        public System.DateTime Time { get; set; }
        public int UserID { get; set; }
        public string Email { get; set; }

        public virtual Users Users { get; set; }
    }
}
